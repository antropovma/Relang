namespace Relang
{
    partial class ConfigurationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.langsDataGrid = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.captionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibleColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.directoryTextLabel = new System.Windows.Forms.Label();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.folderTextLabel = new System.Windows.Forms.Label();
            this.saveOnlyButton = new System.Windows.Forms.Button();
            this.saveAndApplyButton = new System.Windows.Forms.Button();
            this.statusBarConfig = new System.Windows.Forms.StatusStrip();
            this.versionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.langsDataGrid)).BeginInit();
            this.statusBarConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(487, 266);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // langsDataGrid
            // 
            this.langsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.langsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.langsDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.langsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.langsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.langsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.langsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.captionColumn,
            this.visibleColumn});
            this.langsDataGrid.EnableHeadersVisualStyles = false;
            this.langsDataGrid.Location = new System.Drawing.Point(0, 64);
            this.langsDataGrid.Name = "langsDataGrid";
            this.langsDataGrid.RowHeadersWidth = 25;
            this.langsDataGrid.Size = new System.Drawing.Size(574, 196);
            this.langsDataGrid.TabIndex = 1;
            this.langsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.langsDataGrid_CellClick);
            this.langsDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.langsDataGrid_CellValidating);
            this.langsDataGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.langsDataGrid_DefaultValuesNeeded);
            // 
            // nameColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nameColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // captionColumn
            // 
            this.captionColumn.HeaderText = "Caption";
            this.captionColumn.Name = "captionColumn";
            // 
            // visibleColumn
            // 
            this.visibleColumn.HeaderText = "Visible";
            this.visibleColumn.Name = "visibleColumn";
            // 
            // directoryTextLabel
            // 
            this.directoryTextLabel.AutoSize = true;
            this.directoryTextLabel.Location = new System.Drawing.Point(12, 15);
            this.directoryTextLabel.Name = "directoryTextLabel";
            this.directoryTextLabel.Size = new System.Drawing.Size(49, 13);
            this.directoryTextLabel.TabIndex = 2;
            this.directoryTextLabel.Text = "Directory";
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(67, 12);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(495, 20);
            this.directoryTextBox.TabIndex = 3;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(67, 38);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(495, 20);
            this.folderTextBox.TabIndex = 4;
            // 
            // folderTextLabel
            // 
            this.folderTextLabel.AutoSize = true;
            this.folderTextLabel.Location = new System.Drawing.Point(12, 41);
            this.folderTextLabel.Name = "folderTextLabel";
            this.folderTextLabel.Size = new System.Drawing.Size(36, 13);
            this.folderTextLabel.TabIndex = 5;
            this.folderTextLabel.Text = "Folder";
            // 
            // saveOnlyButton
            // 
            this.saveOnlyButton.Location = new System.Drawing.Point(406, 266);
            this.saveOnlyButton.Name = "saveOnlyButton";
            this.saveOnlyButton.Size = new System.Drawing.Size(75, 23);
            this.saveOnlyButton.TabIndex = 6;
            this.saveOnlyButton.Text = "Save only";
            this.saveOnlyButton.UseVisualStyleBackColor = true;
            this.saveOnlyButton.Click += new System.EventHandler(this.saveOnlyButton_Click);
            // 
            // saveAndApplyButton
            // 
            this.saveAndApplyButton.Location = new System.Drawing.Point(290, 266);
            this.saveAndApplyButton.Name = "saveAndApplyButton";
            this.saveAndApplyButton.Size = new System.Drawing.Size(110, 23);
            this.saveAndApplyButton.TabIndex = 7;
            this.saveAndApplyButton.Text = "Save and reload";
            this.saveAndApplyButton.UseVisualStyleBackColor = true;
            this.saveAndApplyButton.Click += new System.EventHandler(this.saveAndApplyButton_Click);
            // 
            // statusBarConfig
            // 
            this.statusBarConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionStatusLabel});
            this.statusBarConfig.Location = new System.Drawing.Point(0, 301);
            this.statusBarConfig.Name = "statusBarConfig";
            this.statusBarConfig.Size = new System.Drawing.Size(574, 22);
            this.statusBarConfig.TabIndex = 8;
            this.statusBarConfig.Text = "statusStrip1";
            // 
            // versionStatusLabel
            // 
            this.versionStatusLabel.Name = "versionStatusLabel";
            this.versionStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 323);
            this.Controls.Add(this.statusBarConfig);
            this.Controls.Add(this.saveAndApplyButton);
            this.Controls.Add(this.saveOnlyButton);
            this.Controls.Add(this.folderTextLabel);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.directoryTextLabel);
            this.Controls.Add(this.langsDataGrid);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.Text = "Relang Settings";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.langsDataGrid)).EndInit();
            this.statusBarConfig.ResumeLayout(false);
            this.statusBarConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView langsDataGrid;
        private System.Windows.Forms.Label directoryTextLabel;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Label folderTextLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn captionColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleColumn;
        private System.Windows.Forms.Button saveOnlyButton;
        private System.Windows.Forms.Button saveAndApplyButton;
        private System.Windows.Forms.StatusStrip statusBarConfig;
        private System.Windows.Forms.ToolStripStatusLabel versionStatusLabel;
    }
}