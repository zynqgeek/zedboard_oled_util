namespace oled_util
{
    partial class Display
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
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxBin = new System.Windows.Forms.PictureBox();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.buttonClose);
            this.groupBoxDisplay.Controls.Add(this.pictureBoxBin);
            this.groupBoxDisplay.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(172, 108);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(35, 69);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(98, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxBin
            // 
            this.pictureBoxBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBin.Location = new System.Drawing.Point(21, 19);
            this.pictureBoxBin.Name = "pictureBoxBin";
            this.pictureBoxBin.Size = new System.Drawing.Size(128, 32);
            this.pictureBoxBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBin.TabIndex = 2;
            this.pictureBoxBin.TabStop = false;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 137);
            this.Controls.Add(this.groupBoxDisplay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Display";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Display";
            this.groupBoxDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.PictureBox pictureBoxBin;
        private System.Windows.Forms.Button buttonClose;

    }
}