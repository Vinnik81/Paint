﻿
namespace WinFormsAppGDI
{
    partial class ImageForm
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
            this.SuspendLayout();
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(759, 386);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}