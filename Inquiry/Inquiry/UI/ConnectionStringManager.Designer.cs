namespace ColdPlace.Inquiry
{
    partial class ConnectionStringManager
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Global Connection Strings", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Project Connection Strings", System.Windows.Forms.HorizontalAlignment.Left);
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.StringList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EditGroup = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.StringName = new System.Windows.Forms.TextBox();
            this.Scope = new System.Windows.Forms.ComboBox();
            this.ServerType = new System.Windows.Forms.ComboBox();
            this.ConnString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // StringList
            // 
            this.StringList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StringList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.StringList.FullRowSelect = true;
            this.StringList.GridLines = true;
            listViewGroup1.Header = "Global Connection Strings";
            listViewGroup1.Name = "GlobalGroup";
            listViewGroup2.Header = "Project Connection Strings";
            listViewGroup2.Name = "ProjectGroup";
            this.StringList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.StringList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StringList.HideSelection = false;
            this.StringList.Location = new System.Drawing.Point(12, 12);
            this.StringList.MultiSelect = false;
            this.StringList.Name = "StringList";
            this.StringList.Size = new System.Drawing.Size(565, 343);
            this.StringList.TabIndex = 0;
            this.StringList.UseCompatibleStateImageBehavior = false;
            this.StringList.View = System.Windows.Forms.View.Details;
            this.StringList.SelectedIndexChanged += new System.EventHandler(this.StringList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 388;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Server Type";
            this.columnHeader2.Width = 159;
            // 
            // OkayButton
            // 
            this.OkayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkayButton.Location = new System.Drawing.Point(583, 546);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 28);
            this.OkayButton.TabIndex = 1;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(583, 512);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 28);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditGroup
            // 
            this.EditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditGroup.Controls.Add(this.SaveButton);
            this.EditGroup.Controls.Add(this.StringName);
            this.EditGroup.Controls.Add(this.Scope);
            this.EditGroup.Controls.Add(this.ServerType);
            this.EditGroup.Controls.Add(this.ConnString);
            this.EditGroup.Controls.Add(this.label4);
            this.EditGroup.Controls.Add(this.label3);
            this.EditGroup.Controls.Add(this.label2);
            this.EditGroup.Controls.Add(this.label1);
            this.EditGroup.Enabled = false;
            this.EditGroup.Location = new System.Drawing.Point(12, 361);
            this.EditGroup.Name = "EditGroup";
            this.EditGroup.Size = new System.Drawing.Size(565, 213);
            this.EditGroup.TabIndex = 3;
            this.EditGroup.TabStop = false;
            this.EditGroup.Text = "Edit Connection String";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(484, 179);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 28);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // StringName
            // 
            this.StringName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StringName.Location = new System.Drawing.Point(136, 60);
            this.StringName.Name = "StringName";
            this.StringName.Size = new System.Drawing.Size(423, 22);
            this.StringName.TabIndex = 7;
            // 
            // Scope
            // 
            this.Scope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Scope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Scope.FormattingEnabled = true;
            this.Scope.Location = new System.Drawing.Point(385, 25);
            this.Scope.Name = "Scope";
            this.Scope.Size = new System.Drawing.Size(174, 24);
            this.Scope.TabIndex = 6;
            // 
            // ServerType
            // 
            this.ServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerType.FormattingEnabled = true;
            this.ServerType.Location = new System.Drawing.Point(136, 25);
            this.ServerType.Name = "ServerType";
            this.ServerType.Size = new System.Drawing.Size(170, 24);
            this.ServerType.TabIndex = 5;
            // 
            // ConnString
            // 
            this.ConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnString.Location = new System.Drawing.Point(136, 92);
            this.ConnString.Multiline = true;
            this.ConnString.Name = "ConnString";
            this.ConnString.Size = new System.Drawing.Size(423, 81);
            this.ConnString.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Connection String:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scope:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Type:";
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(583, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 28);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(583, 46);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 28);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ConnectionStringManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 586);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditGroup);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.StringList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 400);
            this.Name = "ConnectionStringManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection String Manager";
            this.Load += new System.EventHandler(this.ConnectionStringManager_Load);
            this.EditGroup.ResumeLayout(false);
            this.EditGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ListView StringList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button OkayButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox EditGroup;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox StringName;
        private System.Windows.Forms.ComboBox Scope;
        private System.Windows.Forms.ComboBox ServerType;
        private System.Windows.Forms.TextBox ConnString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}