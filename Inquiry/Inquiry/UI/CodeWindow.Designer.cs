namespace ColdPlace.Inquiry
{
    partial class CodeWindow
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
            this.Code = new ScintillaNet.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            this.SuspendLayout();
            // 
            // Code
            // 
            this.Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Code.Location = new System.Drawing.Point(0, 0);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(679, 455);
            this.Code.Styles.BraceBad.FontName = "Verdana";
            this.Code.Styles.BraceLight.FontName = "Verdana";
            this.Code.Styles.ControlChar.FontName = "Verdana";
            this.Code.Styles.Default.FontName = "Verdana";
            this.Code.Styles.IndentGuide.FontName = "Verdana";
            this.Code.Styles.LastPredefined.FontName = "Verdana";
            this.Code.Styles.LineNumber.FontName = "Verdana";
            this.Code.Styles.Max.FontName = "Verdana";
            this.Code.TabIndex = 0;
            // 
            // CodeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 455);
            this.Controls.Add(this.Code);
            this.Name = "CodeWindow";
            this.ShowIcon = false;
            this.Text = "Code";
            this.Load += new System.EventHandler(this.CodeWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNet.Scintilla Code;
    }
}