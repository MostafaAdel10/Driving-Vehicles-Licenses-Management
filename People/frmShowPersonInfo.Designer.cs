﻿namespace DVLD_DrivingLicenseManagement
{
    partial class frmShowPersonInfo
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
            this.lblPersonInformation = new System.Windows.Forms.Label();
            this.ctrlPersonCardd1 = new DVLD_DrivingLicenseManagement.ctrlPersonCardd();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPersonInformation
            // 
            this.lblPersonInformation.AutoSize = true;
            this.lblPersonInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonInformation.ForeColor = System.Drawing.Color.Navy;
            this.lblPersonInformation.Location = new System.Drawing.Point(222, 21);
            this.lblPersonInformation.Name = "lblPersonInformation";
            this.lblPersonInformation.Size = new System.Drawing.Size(436, 54);
            this.lblPersonInformation.TabIndex = 30;
            this.lblPersonInformation.Text = "Person Information";
            this.lblPersonInformation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctrlPersonCardd1
            // 
            this.ctrlPersonCardd1.Location = new System.Drawing.Point(12, 78);
            this.ctrlPersonCardd1.Name = "ctrlPersonCardd1";
            this.ctrlPersonCardd1.Size = new System.Drawing.Size(831, 438);
            this.ctrlPersonCardd1.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD_DrivingLicenseManagement.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(708, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 118;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(857, 568);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonCardd1);
            this.Controls.Add(this.lblPersonInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowPersonInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowPersonInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPersonInformation;
        private ctrlPersonCardd ctrlPersonCardd1;
        private System.Windows.Forms.Button btnClose;
    }
}