using System;
using System.Reflection;
using System.Windows.Forms;

namespace Relang
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            Translator translator = Translator.LoadConfig();
            directoryTextBox.Text = translator.Path;
            folderTextBox.Text = translator.Folder;
            foreach(var lang in translator.Langs)
            {
                langsDataGrid.Rows.Add(lang.Name, lang.Caption, lang.Visible);
            }
            versionStatusLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void saveAndApplyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveConfig();
            Close();
        }

        private void saveOnlyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            SaveConfig();
            Close();
        }

        private void langsDataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["visibleColumn"].Value = true;
        }

        private void langsDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex < langsDataGrid.Rows.Count - 1)
            {
                string headerText = (e.FormattedValue ?? "").ToString();
                if (headerText == "")
                {
                    langsDataGrid.CancelEdit();
                    MessageBox.Show(@"Cannot set value for empty element.");
                }
            }
        }

        private void SaveConfig()
        {
            Translator translator = new Translator
            {
                Path = directoryTextBox.Text,
                Folder = folderTextBox.Text
            };
            for(int row=0; row<langsDataGrid.Rows.Count-1; row++)
            {
                Lang lang = new Lang()
                {
                    Name = langsDataGrid[0, row].Value.ToString(),
                    Caption = langsDataGrid[1, row].Value.ToString(),
                    Visible = (bool)langsDataGrid[2, row].Value
                };
                translator.Langs.Add(lang);
            }
            translator.SaveConfig();
        }

        private void langsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
                langsDataGrid.BeginEdit(true);
        }
    }
}
