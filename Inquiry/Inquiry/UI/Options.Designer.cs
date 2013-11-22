namespace ColdPlace.Inquiry
{
    partial class Options
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ProjectsTab = new System.Windows.Forms.TabPage();
            this.ProjectsProjectPathBrowse = new System.Windows.Forms.Button();
            this.ProjectsProjectPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.ProjectsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.ProjectsTab);
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(399, 78);
            this.Tabs.TabIndex = 0;
            // 
            // ProjectsTab
            // 
            this.ProjectsTab.Controls.Add(this.ProjectsProjectPathBrowse);
            this.ProjectsTab.Controls.Add(this.ProjectsProjectPath);
            this.ProjectsTab.Controls.Add(this.label1);
            this.ProjectsTab.Location = new System.Drawing.Point(4, 25);
            this.ProjectsTab.Name = "ProjectsTab";
            this.ProjectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectsTab.Size = new System.Drawing.Size(391, 49);
            this.ProjectsTab.TabIndex = 0;
            this.ProjectsTab.Text = "Projects";
            this.ProjectsTab.UseVisualStyleBackColor = true;
            // 
            // ProjectsProjectPathBrowse
            // 
            this.ProjectsProjectPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectsProjectPathBrowse.Location = new System.Drawing.Point(355, 13);
            this.ProjectsProjectPathBrowse.Name = "ProjectsProjectPathBrowse";
            this.ProjectsProjectPathBrowse.Size = new System.Drawing.Size(28, 23);
            this.ProjectsProjectPathBrowse.TabIndex = 2;
            this.ProjectsProjectPathBrowse.Text = "...";
            this.ProjectsProjectPathBrowse.UseVisualStyleBackColor = true;
            this.ProjectsProjectPathBrowse.Click += new System.EventHandler(this.ProjectsProjectPathBrowse_Click);
            // 
            // ProjectsProjectPath
            // 
            this.ProjectsProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectsProjectPath.Location = new System.Drawing.Point(103, 13);
            this.ProjectsProjectPath.Name = "ProjectsProjectPath";
            this.ProjectsProjectPath.Size = new System.Drawing.Size(246, 22);
            this.ProjectsProjectPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Path:";
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(312, 84);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 28);
            this.OkayButton.TabIndex = 1;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CancelButton.Location = new System.Drawing.Point(12, 84);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 28);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 124);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.Tabs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.Tabs.ResumeLayout(false);
            this.ProjectsTab.ResumeLayout(false);
            this.ProjectsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage ProjectsTab;
        private System.Windows.Forms.Button OkayButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ProjectsProjectPathBrowse;
        private System.Windows.Forms.TextBox ProjectsProjectPath;
        private System.Windows.Forms.Label label1;
    }
}