using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Relang
{
    public partial class Relang : Form
    {
        Translator _translator;
        public Relang()
        {
            InitializeComponent();
        }

        private void Relang_Load(object sender, EventArgs e)
        {
            _translator = Translator.LoadConfig();
            if (_translator != null)
            {
                directoryTreeView.Nodes.Clear();
                directoryTreeView.Nodes.Add(DirectoryTreeView.Load(_translator.Path, _translator.Folder));
                directoryTreeView.ExpandAll();
            }
        }

        private void UpdateTranslator(object path)
        {
            translatorGrid.Rows.Clear();
            translatorGrid.Columns.Clear();
            translatorGrid.Refresh();
            if (path != null)
            {

                _translator.LoadLangs(path.ToString());
                UpdateDataGrid(_translator);
            }
        }

        private void UpdateDataGrid(Translator translator)
        {
            
            translatorGrid.Columns.Add("name", "Name");
            foreach (var head in translator.GetLangs())
            {
                translatorGrid.Columns.Add(head.Name, head.Caption);
            }
            foreach (var name in translator.GetAllKeys())
            {
                List<string> row = new List<string> {name};
                row.AddRange(from DataGridViewColumn col in translatorGrid.Columns where col.Name != "name" select translator.GetValue(name, col.Name));

                translatorGrid.Rows.Add(row.ToArray<object>());
            }
             
        }

        private void directoryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateTranslator(e.Node.Tag);
        }

        private void translatorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
                translatorGrid.BeginEdit(true);
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTranslator(directoryTreeView.SelectedNode.Tag);
        }

        private void translatorGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < translatorGrid.Rows.Count - 1)
            {
                var headerText = e.ColumnIndex == 0 ? (e.FormattedValue ?? "").ToString() : (translatorGrid[0, e.RowIndex].Value ?? "").ToString();

                string newValue = (e.FormattedValue ?? "").ToString();
                string oldValue = (translatorGrid[e.ColumnIndex, e.RowIndex].Value ?? "").ToString();
                if (headerText == "")
                {
                    translatorGrid.CancelEdit();
                    MessageBox.Show(@"Cannot set value for empty element.");
                    return;
                }
                if (e.ColumnIndex == 0)
                    _translator.RenameKey(oldValue, newValue);

                if (e.ColumnIndex > 0)
                {
                    var value = translatorGrid[0, e.RowIndex].Value;
                    if (value != null)
                        _translator.ChangeLangValue(translatorGrid.Columns[e.ColumnIndex].Name,
                            value.ToString(), newValue);
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            var cell = translatorGrid.CurrentCell;
            translatorGrid.CurrentCell = null;
            translatorGrid.CurrentCell = cell;
            Cursor = Cursors.WaitCursor;
            _translator.Save();
            Cursor = Cursors.Default;
        }

        private void translatorGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if ((translatorGrid[0, e.Row.Index].Value ?? "").ToString() != "")
            {
                var value = translatorGrid[0, e.Row.Index].Value;
                if (value != null)
                {
                    string key = value.ToString();
                    _translator.RemoveKey(key);
                }
            }
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationForm cf = new ConfigurationForm();
            var result = cf.ShowDialog();
            if (result == DialogResult.OK) //if the "Save and reload" button was clicked
            {
                Relang_Load(null, null);
                if (directoryTreeView.Nodes.Count > 0)
                    directoryTreeView.SelectedNode = directoryTreeView.Nodes[0];
            }
        }
    }
}
