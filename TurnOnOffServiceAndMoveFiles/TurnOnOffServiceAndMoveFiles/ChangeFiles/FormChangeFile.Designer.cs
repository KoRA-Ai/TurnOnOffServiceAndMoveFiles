namespace TurnOnOffServiceAndMoveFiles.ChangeFiles
{
    partial class FormChangeFile
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
            this.tbSourcePath = new System.Windows.Forms.TextBox();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.lbSourcePath = new System.Windows.Forms.Label();
            this.lbTargetPath = new System.Windows.Forms.Label();
            this.btnTargetPath = new System.Windows.Forms.Button();
            this.tbTargetPath = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnSaveSourcePath = new System.Windows.Forms.Button();
            this.btnSaveTargetPath = new System.Windows.Forms.Button();
            this.cbSourcePath = new System.Windows.Forms.ComboBox();
            this.cbTargetPath = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSourcePath
            // 
            this.tbSourcePath.Location = new System.Drawing.Point(458, 140);
            this.tbSourcePath.Name = "tbSourcePath";
            this.tbSourcePath.Size = new System.Drawing.Size(320, 22);
            this.tbSourcePath.TabIndex = 0;
            this.tbSourcePath.Visible = false;
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Location = new System.Drawing.Point(434, 26);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(107, 21);
            this.btnSourcePath.TabIndex = 1;
            this.btnSourcePath.Text = "選擇檔案";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            // 
            // lbSourcePath
            // 
            this.lbSourcePath.Location = new System.Drawing.Point(32, 26);
            this.lbSourcePath.Name = "lbSourcePath";
            this.lbSourcePath.Size = new System.Drawing.Size(70, 22);
            this.lbSourcePath.TabIndex = 2;
            this.lbSourcePath.Text = "來源資料夾";
            this.lbSourcePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTargetPath
            // 
            this.lbTargetPath.Location = new System.Drawing.Point(32, 76);
            this.lbTargetPath.Name = "lbTargetPath";
            this.lbTargetPath.Size = new System.Drawing.Size(70, 22);
            this.lbTargetPath.TabIndex = 5;
            this.lbTargetPath.Text = "目標資料夾";
            this.lbTargetPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTargetPath
            // 
            this.btnTargetPath.Location = new System.Drawing.Point(434, 76);
            this.btnTargetPath.Name = "btnTargetPath";
            this.btnTargetPath.Size = new System.Drawing.Size(107, 21);
            this.btnTargetPath.TabIndex = 4;
            this.btnTargetPath.Text = "選擇檔案";
            this.btnTargetPath.UseVisualStyleBackColor = true;
            // 
            // tbTargetPath
            // 
            this.tbTargetPath.Location = new System.Drawing.Point(458, 190);
            this.tbTargetPath.Name = "tbTargetPath";
            this.tbTargetPath.Size = new System.Drawing.Size(320, 22);
            this.tbTargetPath.TabIndex = 3;
            this.tbTargetPath.Visible = false;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLog.Location = new System.Drawing.Point(0, 140);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(800, 310);
            this.tbLog.TabIndex = 6;
            this.tbLog.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 137);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(800, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // btnSaveSourcePath
            // 
            this.btnSaveSourcePath.Location = new System.Drawing.Point(547, 27);
            this.btnSaveSourcePath.Name = "btnSaveSourcePath";
            this.btnSaveSourcePath.Size = new System.Drawing.Size(107, 21);
            this.btnSaveSourcePath.TabIndex = 8;
            this.btnSaveSourcePath.Text = "儲存設置";
            this.btnSaveSourcePath.UseVisualStyleBackColor = true;
            // 
            // btnSaveTargetPath
            // 
            this.btnSaveTargetPath.Location = new System.Drawing.Point(547, 77);
            this.btnSaveTargetPath.Name = "btnSaveTargetPath";
            this.btnSaveTargetPath.Size = new System.Drawing.Size(107, 21);
            this.btnSaveTargetPath.TabIndex = 9;
            this.btnSaveTargetPath.Text = "儲存設置";
            this.btnSaveTargetPath.UseVisualStyleBackColor = true;
            // 
            // cbSourcePath
            // 
            this.cbSourcePath.FormattingEnabled = true;
            this.cbSourcePath.Location = new System.Drawing.Point(108, 27);
            this.cbSourcePath.Name = "cbSourcePath";
            this.cbSourcePath.Size = new System.Drawing.Size(320, 20);
            this.cbSourcePath.TabIndex = 10;
            // 
            // cbTargetPath
            // 
            this.cbTargetPath.FormattingEnabled = true;
            this.cbTargetPath.Location = new System.Drawing.Point(108, 77);
            this.cbTargetPath.Name = "cbTargetPath";
            this.cbTargetPath.Size = new System.Drawing.Size(320, 20);
            this.cbTargetPath.TabIndex = 11;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(660, 76);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(107, 21);
            this.btnExecute.TabIndex = 12;
            this.btnExecute.Text = "執行";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // FormChangeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cbTargetPath);
            this.Controls.Add(this.cbSourcePath);
            this.Controls.Add(this.btnSaveTargetPath);
            this.Controls.Add(this.btnSaveSourcePath);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lbTargetPath);
            this.Controls.Add(this.btnTargetPath);
            this.Controls.Add(this.tbTargetPath);
            this.Controls.Add(this.lbSourcePath);
            this.Controls.Add(this.btnSourcePath);
            this.Controls.Add(this.tbSourcePath);
            this.Name = "FormChangeFile";
            this.Text = "FormChangeFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSourcePath;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.Label lbSourcePath;
        private System.Windows.Forms.Label lbTargetPath;
        private System.Windows.Forms.Button btnTargetPath;
        private System.Windows.Forms.TextBox tbTargetPath;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnSaveSourcePath;
        private System.Windows.Forms.Button btnSaveTargetPath;
        private System.Windows.Forms.ComboBox cbSourcePath;
        private System.Windows.Forms.ComboBox cbTargetPath;
        private System.Windows.Forms.Button btnExecute;
    }
}