﻿namespace DVLD_DrivingLicenseManagement
{
    partial class frmSchedualeTest
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
            this.ctrlSchedualeTest1 = new DVLD_DrivingLicenseManagement.ctrlSchedualeTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSchedualeTest1
            // 
            this.ctrlSchedualeTest1.Location = new System.Drawing.Point(12, 12);
            this.ctrlSchedualeTest1.Name = "ctrlSchedualeTest1";
            this.ctrlSchedualeTest1.Size = new System.Drawing.Size(598, 709);
            this.ctrlSchedualeTest1.TabIndex = 0;
            this.ctrlSchedualeTest1.TestTypeID = DVLD_BusinessLayer.clsTestTypeBusiness.enTestType.VisionTest;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_DrivingLicenseManagement.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(460, 720);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 37);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSchedualeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(611, 771);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlSchedualeTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSchedualeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSchedualeTest";
            this.Load += new System.EventHandler(this.frmSchedualeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSchedualeTest ctrlSchedualeTest1;
        private System.Windows.Forms.Button btnClose;
    }
}