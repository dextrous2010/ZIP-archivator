﻿namespace ZIP_archivator
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.AddButtom = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddButtom
            // 
            this.AddButtom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddButtom.Image = ((System.Drawing.Image)(resources.GetObject("AddButtom.Image")));
            this.AddButtom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddButtom.Location = new System.Drawing.Point(12, 12);
            this.AddButtom.Name = "AddButtom";
            this.AddButtom.Size = new System.Drawing.Size(91, 87);
            this.AddButtom.TabIndex = 0;
            this.AddButtom.Text = "Add";
            this.AddButtom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddButtom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddButtom.UseVisualStyleBackColor = false;
            this.AddButtom.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(109, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 87);
            this.button2.TabIndex = 1;
            this.button2.Text = "Extract To";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddButtom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindowForm";
            this.Text = "ZIP archiver";
            this.Load += new System.EventHandler(this.MainWindowForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddButtom;
        private System.Windows.Forms.Button button2;
    }
}

