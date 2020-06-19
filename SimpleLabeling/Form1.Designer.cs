namespace SimpleLabeling
{
    partial class Form1
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
            this.openImageDirectoryBtn = new System.Windows.Forms.Button();
            this.openImageFileBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // openImageDirectoryBtn
            // 
            this.openImageDirectoryBtn.Location = new System.Drawing.Point(12, 12);
            this.openImageDirectoryBtn.Name = "openImageDirectoryBtn";
            this.openImageDirectoryBtn.Size = new System.Drawing.Size(100, 23);
            this.openImageDirectoryBtn.TabIndex = 0;
            this.openImageDirectoryBtn.Text = "Open Directory";
            this.openImageDirectoryBtn.UseVisualStyleBackColor = true;
            this.openImageDirectoryBtn.Click += new System.EventHandler(this.openImageDirectoryBtn_Click);
            // 
            // openImageFileBtn
            // 
            this.openImageFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openImageFileBtn.Location = new System.Drawing.Point(120, 12);
            this.openImageFileBtn.Name = "openImageFileBtn";
            this.openImageFileBtn.Size = new System.Drawing.Size(100, 23);
            this.openImageFileBtn.TabIndex = 1;
            this.openImageFileBtn.Text = "Open File";
            this.openImageFileBtn.UseVisualStyleBackColor = true;
            this.openImageFileBtn.Click += new System.EventHandler(this.openImageFileBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(12, 41);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 70);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(208, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(93, 41);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(232, 117);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.openImageFileBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openImageDirectoryBtn);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openImageDirectoryBtn;
        private System.Windows.Forms.Button openImageFileBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button saveBtn;
    }
}

