namespace updataAssitant
{
    partial class helpAbout
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
            this.tbcHelpAbout = new System.Windows.Forms.TabControl();
            this.tbpHelp = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbpAbout = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbcHelpAbout.SuspendLayout();
            this.tbpHelp.SuspendLayout();
            this.tbpAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcHelpAbout
            // 
            this.tbcHelpAbout.Controls.Add(this.tbpHelp);
            this.tbcHelpAbout.Controls.Add(this.tbpAbout);
            this.tbcHelpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcHelpAbout.Location = new System.Drawing.Point(0, 0);
            this.tbcHelpAbout.Name = "tbcHelpAbout";
            this.tbcHelpAbout.SelectedIndex = 0;
            this.tbcHelpAbout.Size = new System.Drawing.Size(182, 393);
            this.tbcHelpAbout.TabIndex = 0;
            // 
            // tbpHelp
            // 
            this.tbpHelp.Controls.Add(this.linkLabel1);
            this.tbpHelp.Controls.Add(this.richTextBox1);
            this.tbpHelp.Location = new System.Drawing.Point(4, 22);
            this.tbpHelp.Name = "tbpHelp";
            this.tbpHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHelp.Size = new System.Drawing.Size(174, 367);
            this.tbpHelp.TabIndex = 0;
            this.tbpHelp.Text = "帮助";
            this.tbpHelp.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(168, 361);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tbpAbout
            // 
            this.tbpAbout.Controls.Add(this.pictureBox1);
            this.tbpAbout.Location = new System.Drawing.Point(4, 22);
            this.tbpAbout.Name = "tbpAbout";
            this.tbpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAbout.Size = new System.Drawing.Size(174, 367);
            this.tbpAbout.TabIndex = 1;
            this.tbpAbout.Text = "关于";
            this.tbpAbout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ImageLocation = "http://o9kzgz0kz.bkt.clouddn.com/e92344bace43837d5c99e1df9f5fe23ec29a273e4b94e-91" +
    "ILMf_fw658.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(416, 282);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(31, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(61, 177);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "项目仓库";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // helpAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 393);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbcHelpAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "helpAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "helpAbout";
            this.tbcHelpAbout.ResumeLayout(false);
            this.tbpHelp.ResumeLayout(false);
            this.tbpHelp.PerformLayout();
            this.tbpAbout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcHelpAbout;
        private System.Windows.Forms.TabPage tbpHelp;
        private System.Windows.Forms.TabPage tbpAbout;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}