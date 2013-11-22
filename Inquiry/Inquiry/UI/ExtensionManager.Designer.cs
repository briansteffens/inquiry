namespace ColdPlace.Inquiry
{
    partial class ExtensionManager
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
            this.List = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoadButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.InfoGroup = new System.Windows.Forms.GroupBox();
            this.Info = new System.Windows.Forms.TextBox();
            this.InfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.List.FullRowSelect = true;
            this.List.GridLines = true;
            this.List.HideSelection = false;
            this.List.Location = new System.Drawing.Point(12, 12);
            this.List.MultiSelect = false;
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(517, 184);
            this.List.TabIndex = 0;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Details;
            this.List.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 496;
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Location = new System.Drawing.Point(535, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 28);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load..";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(535, 46);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 28);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(535, 168);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 28);
            this.OkayButton.TabIndex = 3;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(535, 134);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 28);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InfoGroup
            // 
            this.InfoGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoGroup.Controls.Add(this.Info);
            this.InfoGroup.Enabled = false;
            this.InfoGroup.Location = new System.Drawing.Point(12, 202);
            this.InfoGroup.Name = "InfoGroup";
            this.InfoGroup.Size = new System.Drawing.Size(598, 382);
            this.InfoGroup.TabIndex = 5;
            this.InfoGroup.TabStop = false;
            this.InfoGroup.Text = "Extension Information";
            // 
            // Info
            // 
            this.Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Info.BackColor = System.Drawing.SystemColors.Window;
            this.Info.Location = new System.Drawing.Point(6, 21);
            this.Info.Multiline = true;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Info.Size = new System.Drawing.Size(586, 355);
            this.Info.TabIndex = 0;
            // 
            // ExtensionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 596);
            this.Controls.Add(this.InfoGroup);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.List);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtensionManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extension Manager";
            this.Load += new System.EventHandler(this.ExtensionManager_Load);
            this.InfoGroup.ResumeLayout(false);
            this.InfoGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button OkayButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox InfoGroup;
        private System.Windows.Forms.TextBox Info;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}