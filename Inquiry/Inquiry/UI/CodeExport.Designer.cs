namespace ColdPlace.Inquiry
{
    partial class CodeExport
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
            this.LanguageCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExportToCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExportFileText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportFileBrowse = new System.Windows.Forms.Button();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ValueSetCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LanguageCombo
            // 
            this.LanguageCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageCombo.FormattingEnabled = true;
            this.LanguageCombo.Items.AddRange(new object[] {
            "C#"});
            this.LanguageCombo.Location = new System.Drawing.Point(122, 21);
            this.LanguageCombo.Name = "LanguageCombo";
            this.LanguageCombo.Size = new System.Drawing.Size(361, 24);
            this.LanguageCombo.TabIndex = 0;
            this.LanguageCombo.SelectedIndexChanged += new System.EventHandler(this.LanguageCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Export to:";
            // 
            // ExportToCombo
            // 
            this.ExportToCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportToCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExportToCombo.FormattingEnabled = true;
            this.ExportToCombo.Items.AddRange(new object[] {
            "Code window",
            "File"});
            this.ExportToCombo.Location = new System.Drawing.Point(122, 81);
            this.ExportToCombo.Name = "ExportToCombo";
            this.ExportToCombo.Size = new System.Drawing.Size(361, 24);
            this.ExportToCombo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Export file:";
            // 
            // ExportFileText
            // 
            this.ExportFileText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportFileText.Location = new System.Drawing.Point(122, 111);
            this.ExportFileText.Name = "ExportFileText";
            this.ExportFileText.Size = new System.Drawing.Size(325, 22);
            this.ExportFileText.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ValueSetCombo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ExportFileBrowse);
            this.groupBox1.Controls.Add(this.LanguageCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ExportFileText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ExportToCombo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General settings";
            // 
            // ExportFileBrowse
            // 
            this.ExportFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportFileBrowse.Location = new System.Drawing.Point(453, 111);
            this.ExportFileBrowse.Name = "ExportFileBrowse";
            this.ExportFileBrowse.Size = new System.Drawing.Size(30, 23);
            this.ExportFileBrowse.TabIndex = 6;
            this.ExportFileBrowse.Text = "...";
            this.ExportFileBrowse.UseVisualStyleBackColor = true;
            this.ExportFileBrowse.Click += new System.EventHandler(this.ExportFileBrowse_Click);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsGroup.Location = new System.Drawing.Point(12, 160);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(489, 262);
            this.SettingsGroup.TabIndex = 7;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Language settings";
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExportButton.Location = new System.Drawing.Point(426, 428);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 28);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Save";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(12, 428);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 28);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Value set:";
            // 
            // ValueSetCombo
            // 
            this.ValueSetCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueSetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValueSetCombo.FormattingEnabled = true;
            this.ValueSetCombo.Location = new System.Drawing.Point(122, 51);
            this.ValueSetCombo.Name = "ValueSetCombo";
            this.ValueSetCombo.Size = new System.Drawing.Size(361, 24);
            this.ValueSetCombo.TabIndex = 8;
            // 
            // CodeExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 468);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodeExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Code Export";
            this.Load += new System.EventHandler(this.CodeExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox LanguageCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ExportToCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExportFileText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ExportFileBrowse;
        private System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.Button ExportButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox ValueSetCombo;
        private System.Windows.Forms.Label label4;
    }
}