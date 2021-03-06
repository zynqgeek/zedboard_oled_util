﻿namespace oled_util
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
            this.groupBoxBinToPng = new System.Windows.Forms.GroupBox();
            this.buttonClearBin = new System.Windows.Forms.Button();
            this.buttonSavePng = new System.Windows.Forms.Button();
            this.buttonOpenBin = new System.Windows.Forms.Button();
            this.pictureBoxBin = new System.Windows.Forms.PictureBox();
            this.groupBoxPngToBin = new System.Windows.Forms.GroupBox();
            this.buttonClearPng = new System.Windows.Forms.Button();
            this.buttonSaveBin = new System.Windows.Forms.Button();
            this.buttonOpenPng = new System.Windows.Forms.Button();
            this.pictureBoxPng = new System.Windows.Forms.PictureBox();
            this.buttonConvertDirectory = new System.Windows.Forms.Button();
            this.groupBoxBinToPng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBin)).BeginInit();
            this.groupBoxPngToBin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPng)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBinToPng
            // 
            this.groupBoxBinToPng.Controls.Add(this.buttonClearBin);
            this.groupBoxBinToPng.Controls.Add(this.buttonSavePng);
            this.groupBoxBinToPng.Controls.Add(this.buttonOpenBin);
            this.groupBoxBinToPng.Controls.Add(this.pictureBoxBin);
            this.groupBoxBinToPng.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBinToPng.Name = "groupBoxBinToPng";
            this.groupBoxBinToPng.Size = new System.Drawing.Size(272, 122);
            this.groupBoxBinToPng.TabIndex = 1;
            this.groupBoxBinToPng.TabStop = false;
            this.groupBoxBinToPng.Text = "Open/Display .bin File";
            // 
            // buttonClearBin
            // 
            this.buttonClearBin.Location = new System.Drawing.Point(102, 19);
            this.buttonClearBin.Name = "buttonClearBin";
            this.buttonClearBin.Size = new System.Drawing.Size(64, 23);
            this.buttonClearBin.TabIndex = 4;
            this.buttonClearBin.Text = "Clear";
            this.buttonClearBin.UseVisualStyleBackColor = true;
            this.buttonClearBin.Click += new System.EventHandler(this.buttonClearBin_Click);
            // 
            // buttonSavePng
            // 
            this.buttonSavePng.Location = new System.Drawing.Point(172, 19);
            this.buttonSavePng.Name = "buttonSavePng";
            this.buttonSavePng.Size = new System.Drawing.Size(90, 23);
            this.buttonSavePng.TabIndex = 3;
            this.buttonSavePng.Text = "Save as .png File";
            this.buttonSavePng.UseVisualStyleBackColor = true;
            this.buttonSavePng.Click += new System.EventHandler(this.buttonSavePng_Click);
            // 
            // buttonOpenBin
            // 
            this.buttonOpenBin.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenBin.Name = "buttonOpenBin";
            this.buttonOpenBin.Size = new System.Drawing.Size(90, 23);
            this.buttonOpenBin.TabIndex = 2;
            this.buttonOpenBin.Text = "Open .bin File";
            this.buttonOpenBin.UseVisualStyleBackColor = true;
            this.buttonOpenBin.Click += new System.EventHandler(this.buttonOpenBin_Click);
            // 
            // pictureBoxBin
            // 
            this.pictureBoxBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBin.Location = new System.Drawing.Point(65, 63);
            this.pictureBoxBin.Name = "pictureBoxBin";
            this.pictureBoxBin.Size = new System.Drawing.Size(128, 32);
            this.pictureBoxBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBin.TabIndex = 1;
            this.pictureBoxBin.TabStop = false;
            // 
            // groupBoxPngToBin
            // 
            this.groupBoxPngToBin.Controls.Add(this.buttonConvertDirectory);
            this.groupBoxPngToBin.Controls.Add(this.buttonClearPng);
            this.groupBoxPngToBin.Controls.Add(this.buttonSaveBin);
            this.groupBoxPngToBin.Controls.Add(this.buttonOpenPng);
            this.groupBoxPngToBin.Controls.Add(this.pictureBoxPng);
            this.groupBoxPngToBin.Location = new System.Drawing.Point(12, 140);
            this.groupBoxPngToBin.Name = "groupBoxPngToBin";
            this.groupBoxPngToBin.Size = new System.Drawing.Size(272, 122);
            this.groupBoxPngToBin.TabIndex = 2;
            this.groupBoxPngToBin.TabStop = false;
            this.groupBoxPngToBin.Text = "Open/Display .bin File";
            // 
            // buttonClearPng
            // 
            this.buttonClearPng.Location = new System.Drawing.Point(102, 19);
            this.buttonClearPng.Name = "buttonClearPng";
            this.buttonClearPng.Size = new System.Drawing.Size(64, 23);
            this.buttonClearPng.TabIndex = 5;
            this.buttonClearPng.Text = "Clear";
            this.buttonClearPng.UseVisualStyleBackColor = true;
            this.buttonClearPng.Click += new System.EventHandler(this.buttonClearPng_Click);
            // 
            // buttonSaveBin
            // 
            this.buttonSaveBin.Location = new System.Drawing.Point(172, 19);
            this.buttonSaveBin.Name = "buttonSaveBin";
            this.buttonSaveBin.Size = new System.Drawing.Size(90, 23);
            this.buttonSaveBin.TabIndex = 3;
            this.buttonSaveBin.Text = "Save as .bin File";
            this.buttonSaveBin.UseVisualStyleBackColor = true;
            this.buttonSaveBin.Click += new System.EventHandler(this.buttonSaveBin_Click);
            // 
            // buttonOpenPng
            // 
            this.buttonOpenPng.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenPng.Name = "buttonOpenPng";
            this.buttonOpenPng.Size = new System.Drawing.Size(90, 23);
            this.buttonOpenPng.TabIndex = 2;
            this.buttonOpenPng.Text = "Open .png File";
            this.buttonOpenPng.UseVisualStyleBackColor = true;
            this.buttonOpenPng.Click += new System.EventHandler(this.buttonOpenPng_Click);
            // 
            // pictureBoxPng
            // 
            this.pictureBoxPng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPng.Location = new System.Drawing.Point(65, 53);
            this.pictureBoxPng.Name = "pictureBoxPng";
            this.pictureBoxPng.Size = new System.Drawing.Size(128, 32);
            this.pictureBoxPng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPng.TabIndex = 1;
            this.pictureBoxPng.TabStop = false;
            // 
            // buttonConvertDirectory
            // 
            this.buttonConvertDirectory.Location = new System.Drawing.Point(61, 93);
            this.buttonConvertDirectory.Name = "buttonConvertDirectory";
            this.buttonConvertDirectory.Size = new System.Drawing.Size(132, 23);
            this.buttonConvertDirectory.TabIndex = 6;
            this.buttonConvertDirectory.Text = "Convert Entire Directory";
            this.buttonConvertDirectory.UseVisualStyleBackColor = true;
            this.buttonConvertDirectory.Click += new System.EventHandler(this.buttonConvertDirectory_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 280);
            this.Controls.Add(this.groupBoxPngToBin);
            this.Controls.Add(this.groupBoxBinToPng);
            this.Name = "FormMain";
            this.Text = "Zedboard OLED Utility";
            this.groupBoxBinToPng.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBin)).EndInit();
            this.groupBoxPngToBin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPng)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBinToPng;
        private System.Windows.Forms.Button buttonOpenBin;
        private System.Windows.Forms.PictureBox pictureBoxBin;
        private System.Windows.Forms.Button buttonSavePng;
        private System.Windows.Forms.GroupBox groupBoxPngToBin;
        private System.Windows.Forms.Button buttonSaveBin;
        private System.Windows.Forms.Button buttonOpenPng;
        private System.Windows.Forms.PictureBox pictureBoxPng;
        private System.Windows.Forms.Button buttonClearBin;
        private System.Windows.Forms.Button buttonClearPng;
        private System.Windows.Forms.Button buttonConvertDirectory;

    }
}

