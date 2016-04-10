namespace Relang
{
    partial class Relang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relang));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.directoryTreeView = new System.Windows.Forms.TreeView();
            this.translatorGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.translatorGrid)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.directoryTreeView);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.translatorGrid);
            this.splitContainer.Panel2.Controls.Add(this.mainMenu);
            this.splitContainer.Panel2MinSize = 400;
            this.splitContainer.Size = new System.Drawing.Size(853, 416);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            // 
            // directoryTreeView
            // 
            this.directoryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryTreeView.Location = new System.Drawing.Point(0, 0);
            this.directoryTreeView.Name = "directoryTreeView";
            this.directoryTreeView.ShowNodeToolTips = true;
            this.directoryTreeView.Size = new System.Drawing.Size(196, 412);
            this.directoryTreeView.TabIndex = 1;
            this.directoryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directoryTreeView_AfterSelect);
            // 
            // translatorGrid
            // 
            this.translatorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.translatorGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.translatorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.translatorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.translatorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.translatorGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.translatorGrid.EnableHeadersVisualStyles = false;
            this.translatorGrid.Location = new System.Drawing.Point(0, 24);
            this.translatorGrid.Name = "translatorGrid";
            this.translatorGrid.RowHeadersWidth = 25;
            this.translatorGrid.Size = new System.Drawing.Size(647, 388);
            this.translatorGrid.TabIndex = 0;
            this.translatorGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.translatorGrid_CellClick);
            this.translatorGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.translatorGrid_CellValidating);
            this.translatorGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.translatorGrid_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshMenuItem,
            this.saveMenuItem,
            this.settingsMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.ShowItemToolTips = true;
            this.mainMenu.Size = new System.Drawing.Size(647, 24);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshMenuItem.Image = global::Relang.Properties.Resources.refresh;
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshMenuItem.Size = new System.Drawing.Size(28, 20);
            this.refreshMenuItem.Text = "toolStripMenuItem1";
            this.refreshMenuItem.ToolTipText = "Refresh (F5)";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveMenuItem.Image = global::Relang.Properties.Resources.save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(28, 20);
            this.saveMenuItem.Text = "toolStripMenuItem2";
            this.saveMenuItem.ToolTipText = "Save all (Ctrl+S)";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsMenuItem.Image = global::Relang.Properties.Resources.settings;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.settingsMenuItem.Size = new System.Drawing.Size(28, 20);
            this.settingsMenuItem.Text = "toolStripMenuItem3";
            this.settingsMenuItem.ToolTipText = "Settings (Ctrl+O)";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // Relang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 416);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(869, 454);
            this.Name = "Relang";
            this.Text = "Relang";
            this.Load += new System.EventHandler(this.Relang_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.translatorGrid)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView directoryTreeView;
        private System.Windows.Forms.DataGridView translatorGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
    }
}

