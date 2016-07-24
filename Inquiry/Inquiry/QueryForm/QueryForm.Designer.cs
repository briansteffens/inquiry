namespace ColdPlace.Inquiry
{
    partial class QueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.QueryText = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ResultsTabs = new System.Windows.Forms.TabControl();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DatabaseCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TabPage();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.Results = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ResultSetTabs = new System.Windows.Forms.TabControl();
            this.ResultsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.currentTabToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTabsToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.RecordCount = new System.Windows.Forms.ToolStripLabel();
            this.ValueTextView = new System.Windows.Forms.TextBox();
            this.Schema = new System.Windows.Forms.TabPage();
            this.SchemaView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SchemaToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshSchemaButton = new System.Windows.Forms.ToolStripButton();
            this.ParentSchemaButton = new System.Windows.Forms.ToolStripButton();
            this.RawSchema = new System.Windows.Forms.TabPage();
            this.RawSchemaToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.RawSchemaTypeText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.RawSchemaRestraint1Text = new System.Windows.Forms.ToolStripTextBox();
            this.RawSchemaRestraint2Text = new System.Windows.Forms.ToolStripTextBox();
            this.RawSchemaRestraint3Text = new System.Windows.Forms.ToolStripTextBox();
            this.RawSchemaRestraint4Text = new System.Windows.Forms.ToolStripTextBox();
            this.RawSchemaSearch = new System.Windows.Forms.ToolStripButton();
            this.RawSchemaView = new System.Windows.Forms.DataGridView();
            this.TextProcessorTab = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.TextProcessorList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextProcessorDescription = new System.Windows.Forms.Label();
            this.TextProcessorParams = new System.Windows.Forms.GroupBox();
            this.Process = new System.Windows.Forms.Button();
            this.FinalQuery = new System.Windows.Forms.TabPage();
            this.FinalQueryText = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ExecuteButton = new System.Windows.Forms.ToolStripButton();
            this.ServerTypeLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SafeQueryMode = new System.Windows.Forms.ToolStripButton();
            this.QueryProgress = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ResultsTabs.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.Output.SuspendLayout();
            this.Results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ResultsToolStrip.SuspendLayout();
            this.Schema.SuspendLayout();
            this.SchemaToolStrip.SuspendLayout();
            this.RawSchema.SuspendLayout();
            this.RawSchemaToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawSchemaView)).BeginInit();
            this.TextProcessorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.FinalQuery.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QueryText
            // 
            this.QueryText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryText.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryText.Location = new System.Drawing.Point(0, 3);
            this.QueryText.Multiline = true;
            this.QueryText.Name = "QueryText";
            this.QueryText.Size = new System.Drawing.Size(514, 143);
            this.QueryText.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 27);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.QueryText);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ResultsTabs);
            this.splitContainer2.Size = new System.Drawing.Size(514, 347);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // ResultsTabs
            // 
            this.ResultsTabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.ResultsTabs.Controls.Add(this.SettingsTab);
            this.ResultsTabs.Controls.Add(this.Output);
            this.ResultsTabs.Controls.Add(this.Results);
            this.ResultsTabs.Controls.Add(this.Schema);
            this.ResultsTabs.Controls.Add(this.RawSchema);
            this.ResultsTabs.Controls.Add(this.TextProcessorTab);
            this.ResultsTabs.Controls.Add(this.FinalQuery);
            this.ResultsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTabs.Location = new System.Drawing.Point(0, 0);
            this.ResultsTabs.Multiline = true;
            this.ResultsTabs.Name = "ResultsTabs";
            this.ResultsTabs.SelectedIndex = 0;
            this.ResultsTabs.Size = new System.Drawing.Size(514, 197);
            this.ResultsTabs.TabIndex = 1;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.DescriptionText);
            this.SettingsTab.Controls.Add(this.label3);
            this.SettingsTab.Controls.Add(this.DatabaseCombo);
            this.SettingsTab.Controls.Add(this.label2);
            this.SettingsTab.Location = new System.Drawing.Point(4, 4);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(506, 168);
            this.SettingsTab.TabIndex = 4;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.Location = new System.Drawing.Point(104, 49);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DescriptionText.Size = new System.Drawing.Size(394, 101);
            this.DescriptionText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            // 
            // DatabaseCombo
            // 
            this.DatabaseCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatabaseCombo.FormattingEnabled = true;
            this.DatabaseCombo.Location = new System.Drawing.Point(104, 19);
            this.DatabaseCombo.Name = "DatabaseCombo";
            this.DatabaseCombo.Size = new System.Drawing.Size(394, 24);
            this.DatabaseCombo.TabIndex = 3;
            this.DatabaseCombo.SelectedIndexChanged += new System.EventHandler(this.DatabaseCombo_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database:";
            // 
            // Output
            // 
            this.Output.Controls.Add(this.OutputText);
            this.Output.Location = new System.Drawing.Point(4, 4);
            this.Output.Name = "Output";
            this.Output.Padding = new System.Windows.Forms.Padding(3);
            this.Output.Size = new System.Drawing.Size(506, 168);
            this.Output.TabIndex = 0;
            this.Output.Text = "Output";
            this.Output.UseVisualStyleBackColor = true;
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.SystemColors.Window;
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Location = new System.Drawing.Point(3, 3);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputText.Size = new System.Drawing.Size(797, 383);
            this.OutputText.TabIndex = 0;
            // 
            // Results
            // 
            this.Results.Controls.Add(this.splitContainer1);
            this.Results.Location = new System.Drawing.Point(4, 4);
            this.Results.Name = "Results";
            this.Results.Padding = new System.Windows.Forms.Padding(3);
            this.Results.Size = new System.Drawing.Size(506, 168);
            this.Results.TabIndex = 1;
            this.Results.Text = "Results";
            this.Results.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ResultSetTabs);
            this.splitContainer1.Panel1.Controls.Add(this.ResultsToolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ValueTextView);
            this.splitContainer1.Size = new System.Drawing.Size(797, 383);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 3;
            // 
            // ResultSetTabs
            // 
            this.ResultSetTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultSetTabs.Location = new System.Drawing.Point(0, 27);
            this.ResultSetTabs.Name = "ResultSetTabs";
            this.ResultSetTabs.SelectedIndex = 0;
            this.ResultSetTabs.Size = new System.Drawing.Size(797, 264);
            this.ResultSetTabs.TabIndex = 2;
            // 
            // ResultsToolStrip
            // 
            this.ResultsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ResultsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripLabel1,
            this.RecordCount});
            this.ResultsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ResultsToolStrip.Name = "ResultsToolStrip";
            this.ResultsToolStrip.Size = new System.Drawing.Size(797, 27);
            this.ResultsToolStrip.TabIndex = 1;
            this.ResultsToolStrip.Text = "toolStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentTabToCSVToolStripMenuItem,
            this.allTabsToExcelToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(65, 24);
            this.toolStripSplitButton1.Text = "Export";
            // 
            // currentTabToCSVToolStripMenuItem
            // 
            this.currentTabToCSVToolStripMenuItem.Name = "currentTabToCSVToolStripMenuItem";
            this.currentTabToCSVToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.currentTabToCSVToolStripMenuItem.Text = "Current tab to CSV";
            this.currentTabToCSVToolStripMenuItem.Click += new System.EventHandler(this.currentTabToCSVToolStripMenuItem_Click);
            // 
            // allTabsToExcelToolStripMenuItem
            // 
            this.allTabsToExcelToolStripMenuItem.Name = "allTabsToExcelToolStripMenuItem";
            this.allTabsToExcelToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 24);
            this.toolStripLabel1.Text = "Records:";
            // 
            // RecordCount
            // 
            this.RecordCount.Name = "RecordCount";
            this.RecordCount.Size = new System.Drawing.Size(0, 24);
            // 
            // ValueTextView
            // 
            this.ValueTextView.BackColor = System.Drawing.SystemColors.Window;
            this.ValueTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueTextView.Location = new System.Drawing.Point(0, 0);
            this.ValueTextView.Multiline = true;
            this.ValueTextView.Name = "ValueTextView";
            this.ValueTextView.ReadOnly = true;
            this.ValueTextView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValueTextView.Size = new System.Drawing.Size(797, 86);
            this.ValueTextView.TabIndex = 0;
            // 
            // Schema
            // 
            this.Schema.Controls.Add(this.SchemaView);
            this.Schema.Controls.Add(this.SchemaToolStrip);
            this.Schema.Location = new System.Drawing.Point(4, 4);
            this.Schema.Name = "Schema";
            this.Schema.Size = new System.Drawing.Size(506, 168);
            this.Schema.TabIndex = 3;
            this.Schema.Text = "Schema";
            this.Schema.UseVisualStyleBackColor = true;
            // 
            // SchemaView
            // 
            this.SchemaView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SchemaView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchemaView.FullRowSelect = true;
            this.SchemaView.GridLines = true;
            this.SchemaView.Location = new System.Drawing.Point(0, 27);
            this.SchemaView.MultiSelect = false;
            this.SchemaView.Name = "SchemaView";
            this.SchemaView.Size = new System.Drawing.Size(506, 141);
            this.SchemaView.TabIndex = 0;
            this.SchemaView.UseCompatibleStateImageBehavior = false;
            this.SchemaView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Schema Object";
            this.columnHeader1.Width = 189;
            // 
            // SchemaToolStrip
            // 
            this.SchemaToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SchemaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshSchemaButton,
            this.ParentSchemaButton});
            this.SchemaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SchemaToolStrip.Name = "SchemaToolStrip";
            this.SchemaToolStrip.Size = new System.Drawing.Size(506, 27);
            this.SchemaToolStrip.TabIndex = 1;
            this.SchemaToolStrip.Text = "toolStrip2";
            // 
            // RefreshSchemaButton
            // 
            this.RefreshSchemaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshSchemaButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshSchemaButton.Image")));
            this.RefreshSchemaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshSchemaButton.Name = "RefreshSchemaButton";
            this.RefreshSchemaButton.Size = new System.Drawing.Size(62, 24);
            this.RefreshSchemaButton.Text = "Refresh";
            this.RefreshSchemaButton.Click += new System.EventHandler(this.RefreshSchemaButton_Click);
            // 
            // ParentSchemaButton
            // 
            this.ParentSchemaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ParentSchemaButton.Image = ((System.Drawing.Image)(resources.GetObject("ParentSchemaButton.Image")));
            this.ParentSchemaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParentSchemaButton.Name = "ParentSchemaButton";
            this.ParentSchemaButton.Size = new System.Drawing.Size(55, 24);
            this.ParentSchemaButton.Text = "Parent";
            this.ParentSchemaButton.Click += new System.EventHandler(this.ParentSchemaButton_Click);
            // 
            // RawSchema
            // 
            this.RawSchema.Controls.Add(this.RawSchemaToolStrip);
            this.RawSchema.Controls.Add(this.RawSchemaView);
            this.RawSchema.Location = new System.Drawing.Point(4, 4);
            this.RawSchema.Name = "RawSchema";
            this.RawSchema.Size = new System.Drawing.Size(506, 168);
            this.RawSchema.TabIndex = 2;
            this.RawSchema.Text = "Raw Schema";
            this.RawSchema.UseVisualStyleBackColor = true;
            // 
            // RawSchemaToolStrip
            // 
            this.RawSchemaToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.RawSchemaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.RawSchemaTypeText,
            this.toolStripLabel4,
            this.RawSchemaRestraint1Text,
            this.RawSchemaRestraint2Text,
            this.RawSchemaRestraint3Text,
            this.RawSchemaRestraint4Text,
            this.RawSchemaSearch});
            this.RawSchemaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.RawSchemaToolStrip.Name = "RawSchemaToolStrip";
            this.RawSchemaToolStrip.Size = new System.Drawing.Size(506, 29);
            this.RawSchemaToolStrip.TabIndex = 1;
            this.RawSchemaToolStrip.Text = "toolStrip2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(44, 26);
            this.toolStripLabel3.Text = "Type:";
            // 
            // RawSchemaTypeText
            // 
            this.RawSchemaTypeText.Name = "RawSchemaTypeText";
            this.RawSchemaTypeText.Size = new System.Drawing.Size(125, 29);
            this.RawSchemaTypeText.Text = "Databases";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(76, 26);
            this.toolStripLabel4.Text = "Restraints:";
            // 
            // RawSchemaRestraint1Text
            // 
            this.RawSchemaRestraint1Text.Name = "RawSchemaRestraint1Text";
            this.RawSchemaRestraint1Text.Size = new System.Drawing.Size(125, 29);
            // 
            // RawSchemaRestraint2Text
            // 
            this.RawSchemaRestraint2Text.Name = "RawSchemaRestraint2Text";
            this.RawSchemaRestraint2Text.Size = new System.Drawing.Size(125, 27);
            // 
            // RawSchemaRestraint3Text
            // 
            this.RawSchemaRestraint3Text.Name = "RawSchemaRestraint3Text";
            this.RawSchemaRestraint3Text.Size = new System.Drawing.Size(125, 27);
            // 
            // RawSchemaRestraint4Text
            // 
            this.RawSchemaRestraint4Text.Name = "RawSchemaRestraint4Text";
            this.RawSchemaRestraint4Text.Size = new System.Drawing.Size(125, 27);
            // 
            // RawSchemaSearch
            // 
            this.RawSchemaSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RawSchemaSearch.Image = ((System.Drawing.Image)(resources.GetObject("RawSchemaSearch.Image")));
            this.RawSchemaSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RawSchemaSearch.Name = "RawSchemaSearch";
            this.RawSchemaSearch.Size = new System.Drawing.Size(57, 24);
            this.RawSchemaSearch.Text = "Search";
            this.RawSchemaSearch.Click += new System.EventHandler(this.RawSchemaSearch_Click);
            // 
            // RawSchemaView
            // 
            this.RawSchemaView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RawSchemaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawSchemaView.Location = new System.Drawing.Point(0, 28);
            this.RawSchemaView.Name = "RawSchemaView";
            this.RawSchemaView.RowTemplate.Height = 24;
            this.RawSchemaView.Size = new System.Drawing.Size(844, 396);
            this.RawSchemaView.TabIndex = 0;
            // 
            // TextProcessorTab
            // 
            this.TextProcessorTab.Controls.Add(this.splitContainer3);
            this.TextProcessorTab.Location = new System.Drawing.Point(4, 4);
            this.TextProcessorTab.Name = "TextProcessorTab";
            this.TextProcessorTab.Size = new System.Drawing.Size(506, 168);
            this.TextProcessorTab.TabIndex = 5;
            this.TextProcessorTab.Text = "Text Processor";
            this.TextProcessorTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.TextProcessorList);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Panel2.Controls.Add(this.TextProcessorParams);
            this.splitContainer3.Panel2.Controls.Add(this.Process);
            this.splitContainer3.Size = new System.Drawing.Size(803, 389);
            this.splitContainer3.SplitterDistance = 331;
            this.splitContainer3.TabIndex = 0;
            // 
            // TextProcessorList
            // 
            this.TextProcessorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.TextProcessorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextProcessorList.FullRowSelect = true;
            this.TextProcessorList.GridLines = true;
            this.TextProcessorList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TextProcessorList.HideSelection = false;
            this.TextProcessorList.Location = new System.Drawing.Point(0, 0);
            this.TextProcessorList.MultiSelect = false;
            this.TextProcessorList.Name = "TextProcessorList";
            this.TextProcessorList.Size = new System.Drawing.Size(331, 389);
            this.TextProcessorList.TabIndex = 0;
            this.TextProcessorList.UseCompatibleStateImageBehavior = false;
            this.TextProcessorList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Text Processor";
            this.columnHeader2.Width = 314;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TextProcessorDescription);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // TextProcessorDescription
            // 
            this.TextProcessorDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextProcessorDescription.Location = new System.Drawing.Point(3, 18);
            this.TextProcessorDescription.Name = "TextProcessorDescription";
            this.TextProcessorDescription.Size = new System.Drawing.Size(456, 61);
            this.TextProcessorDescription.TabIndex = 0;
            this.TextProcessorDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TextProcessorParams
            // 
            this.TextProcessorParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextProcessorParams.Location = new System.Drawing.Point(3, 91);
            this.TextProcessorParams.Name = "TextProcessorParams";
            this.TextProcessorParams.Size = new System.Drawing.Size(462, 256);
            this.TextProcessorParams.TabIndex = 2;
            this.TextProcessorParams.TabStop = false;
            this.TextProcessorParams.Text = "Parameters";
            // 
            // Process
            // 
            this.Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Process.Location = new System.Drawing.Point(385, 353);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(75, 28);
            this.Process.TabIndex = 1;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // FinalQuery
            // 
            this.FinalQuery.Controls.Add(this.FinalQueryText);
            this.FinalQuery.Location = new System.Drawing.Point(4, 4);
            this.FinalQuery.Name = "FinalQuery";
            this.FinalQuery.Size = new System.Drawing.Size(506, 168);
            this.FinalQuery.TabIndex = 6;
            this.FinalQuery.Text = "Final Query";
            this.FinalQuery.UseVisualStyleBackColor = true;
            // 
            // FinalQueryText
            // 
            this.FinalQueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinalQueryText.Location = new System.Drawing.Point(0, 0);
            this.FinalQueryText.Multiline = true;
            this.FinalQueryText.Name = "FinalQueryText";
            this.FinalQueryText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FinalQueryText.Size = new System.Drawing.Size(803, 389);
            this.FinalQueryText.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExecuteButton,
            this.ServerTypeLabel,
            this.toolStripSeparator1,
            this.SafeQueryMode,
            this.QueryProgress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(514, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExecuteButton.Image = ((System.Drawing.Image)(resources.GetObject("ExecuteButton.Image")));
            this.ExecuteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(64, 24);
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ServerTypeLabel
            // 
            this.ServerTypeLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ServerTypeLabel.Name = "ServerTypeLabel";
            this.ServerTypeLabel.Size = new System.Drawing.Size(107, 24);
            this.ServerTypeLabel.Text = "Not connected";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // SafeQueryMode
            // 
            this.SafeQueryMode.CheckOnClick = true;
            this.SafeQueryMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SafeQueryMode.Image = ((System.Drawing.Image)(resources.GetObject("SafeQueryMode.Image")));
            this.SafeQueryMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SafeQueryMode.Name = "SafeQueryMode";
            this.SafeQueryMode.Size = new System.Drawing.Size(85, 24);
            this.SafeQueryMode.Text = "Safe Mode";
            this.SafeQueryMode.Click += new System.EventHandler(this.SafeQueryMode_Click);
            // 
            // QueryProgress
            // 
            this.QueryProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QueryProgress.MarqueeAnimationSpeed = 50;
            this.QueryProgress.Name = "QueryProgress";
            this.QueryProgress.Size = new System.Drawing.Size(200, 24);
            this.QueryProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.QueryProgress.Visible = false;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 374);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "QueryForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Query";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResultsTabs.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.Output.ResumeLayout(false);
            this.Output.PerformLayout();
            this.Results.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResultsToolStrip.ResumeLayout(false);
            this.ResultsToolStrip.PerformLayout();
            this.Schema.ResumeLayout(false);
            this.Schema.PerformLayout();
            this.SchemaToolStrip.ResumeLayout(false);
            this.SchemaToolStrip.PerformLayout();
            this.RawSchema.ResumeLayout(false);
            this.RawSchema.PerformLayout();
            this.RawSchemaToolStrip.ResumeLayout(false);
            this.RawSchemaToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RawSchemaView)).EndInit();
            this.TextProcessorTab.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.FinalQuery.ResumeLayout(false);
            this.FinalQuery.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QueryText;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl ResultsTabs;
        private System.Windows.Forms.TabPage Output;
        private System.Windows.Forms.TabPage Results;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.ToolStrip SchemaToolStrip;
        private System.Windows.Forms.ToolStripButton RefreshSchemaButton;
        private System.Windows.Forms.ListView SchemaView;
        private System.Windows.Forms.ToolStripButton ParentSchemaButton;
        private System.Windows.Forms.ToolStripLabel ServerTypeLabel;
        private System.Windows.Forms.ToolStrip ResultsToolStrip;
        private System.Windows.Forms.TabPage RawSchema;
        private System.Windows.Forms.DataGridView RawSchemaView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage Schema;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip RawSchemaToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox RawSchemaTypeText;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox RawSchemaRestraint1Text;
        private System.Windows.Forms.ToolStripTextBox RawSchemaRestraint2Text;
        private System.Windows.Forms.ToolStripTextBox RawSchemaRestraint3Text;
        private System.Windows.Forms.ToolStripTextBox RawSchemaRestraint4Text;
        private System.Windows.Forms.ToolStripButton RawSchemaSearch;
        private System.Windows.Forms.ToolStripButton ExecuteButton;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DatabaseCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel RecordCount;
        private System.Windows.Forms.TabPage TextProcessorTab;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView TextProcessorList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.GroupBox TextProcessorParams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TextProcessorDescription;
        private System.Windows.Forms.TabPage FinalQuery;
        private System.Windows.Forms.ToolStripButton SafeQueryMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar QueryProgress;
        private System.Windows.Forms.TextBox FinalQueryText;
        private System.Windows.Forms.TextBox ValueTextView;
        private System.Windows.Forms.TabControl ResultSetTabs;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem currentTabToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTabsToExcelToolStripMenuItem;
    }
}

