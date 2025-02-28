namespace TurnOnOffService
{
    partial class FormMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabService = new System.Windows.Forms.TabPage();
            this.tabChangeFile = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabService);
            this.tabControl1.Controls.Add(this.tabChangeFile);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabService
            // 
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(792, 424);
            this.tabService.TabIndex = 0;
            this.tabService.Text = "開關服務";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // tabChangeFile
            // 
            this.tabChangeFile.Location = new System.Drawing.Point(4, 22);
            this.tabChangeFile.Name = "tabChangeFile";
            this.tabChangeFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabChangeFile.Size = new System.Drawing.Size(792, 424);
            this.tabChangeFile.TabIndex = 1;
            this.tabChangeFile.Text = "更換檔案";
            this.tabChangeFile.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.TabPage tabChangeFile;
    }
}