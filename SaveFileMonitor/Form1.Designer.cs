namespace SaveFileMonitor
{
    partial class save_file_form
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSelectFile = new System.Windows.Forms.Label();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.lblOutputDir = new System.Windows.Forms.Label();
            this.cbTimestampFormat = new System.Windows.Forms.ComboBox();
            this.tbCustomSaveFileName = new System.Windows.Forms.TextBox();
            this.lbCustomFileName = new System.Windows.Forms.Label();
            this.lblTimestampformat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(52, 62);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(112, 39);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(52, 187);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(82, 39);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(48, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 20);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Program Status";
            // 
            // lblSelectFile
            // 
            this.lblSelectFile.AutoSize = true;
            this.lblSelectFile.Location = new System.Drawing.Point(256, 71);
            this.lblSelectFile.Name = "lblSelectFile";
            this.lblSelectFile.Size = new System.Drawing.Size(125, 20);
            this.lblSelectFile.TabIndex = 4;
            this.lblSelectFile.Text = "No File Selected";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(53, 123);
            this.btnOutputDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(174, 46);
            this.btnOutputDir.TabIndex = 5;
            this.btnOutputDir.Text = "Select Output Dir";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnSelectOutputDir_Click);
            // 
            // lblOutputDir
            // 
            this.lblOutputDir.AutoSize = true;
            this.lblOutputDir.Location = new System.Drawing.Point(256, 136);
            this.lblOutputDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDir.Name = "lblOutputDir";
            this.lblOutputDir.Size = new System.Drawing.Size(216, 20);
            this.lblOutputDir.TabIndex = 6;
            this.lblOutputDir.Text = "No Output Directory Selected";
            // 
            // cbTimestampFormat
            // 
            this.cbTimestampFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTimestampFormat.FormattingEnabled = true;
            this.cbTimestampFormat.Location = new System.Drawing.Point(575, 352);
            this.cbTimestampFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTimestampFormat.Name = "cbTimestampFormat";
            this.cbTimestampFormat.Size = new System.Drawing.Size(201, 28);
            this.cbTimestampFormat.TabIndex = 10;
            this.cbTimestampFormat.Text = "Timestamp Format";
            // 
            // tbCustomSaveFileName
            // 
            this.tbCustomSaveFileName.Location = new System.Drawing.Point(193, 352);
            this.tbCustomSaveFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCustomSaveFileName.Name = "tbCustomSaveFileName";
            this.tbCustomSaveFileName.Size = new System.Drawing.Size(186, 26);
            this.tbCustomSaveFileName.TabIndex = 12;
            // 
            // lbCustomFileName
            // 
            this.lbCustomFileName.AutoSize = true;
            this.lbCustomFileName.Location = new System.Drawing.Point(48, 355);
            this.lbCustomFileName.Name = "lbCustomFileName";
            this.lbCustomFileName.Size = new System.Drawing.Size(139, 20);
            this.lbCustomFileName.TabIndex = 11;
            this.lbCustomFileName.Text = "Custom File Name";
            // 
            // lblTimestampformat
            // 
            this.lblTimestampformat.AutoSize = true;
            this.lblTimestampformat.Location = new System.Drawing.Point(427, 355);
            this.lblTimestampformat.Name = "lblTimestampformat";
            this.lblTimestampformat.Size = new System.Drawing.Size(142, 20);
            this.lblTimestampformat.TabIndex = 13;
            this.lblTimestampformat.Text = "Timestamp Format";
            // 
            // save_file_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.lblTimestampformat);
            this.Controls.Add(this.tbCustomSaveFileName);
            this.Controls.Add(this.lbCustomFileName);
            this.Controls.Add(this.cbTimestampFormat);
            this.Controls.Add(this.lblOutputDir);
            this.Controls.Add(this.btnOutputDir);
            this.Controls.Add(this.lblSelectFile);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSelectFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "save_file_form";
            this.Text = "Save File Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSelectFile;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.Label lblOutputDir;
        private System.Windows.Forms.ComboBox cbTimestampFormat;
        private System.Windows.Forms.TextBox tbCustomSaveFileName;
        private System.Windows.Forms.Label lbCustomFileName;
        private System.Windows.Forms.Label lblTimestampformat;
    }
}

