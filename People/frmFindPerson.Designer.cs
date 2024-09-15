namespace DVLD_DrivingLicenseManagement
{
    partial class frmFindPerson
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
            this.lblFindPerson = new System.Windows.Forms.Label();
            this.ctrlPersonCarddWithFilter1 = new DVLD_DrivingLicenseManagement.ctrlPersonCarddWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFindPerson
            // 
            this.lblFindPerson.AutoSize = true;
            this.lblFindPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindPerson.ForeColor = System.Drawing.Color.Navy;
            this.lblFindPerson.Location = new System.Drawing.Point(318, 9);
            this.lblFindPerson.Name = "lblFindPerson";
            this.lblFindPerson.Size = new System.Drawing.Size(286, 54);
            this.lblFindPerson.TabIndex = 29;
            this.lblFindPerson.Text = "Find Person";
            this.lblFindPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctrlPersonCarddWithFilter1
            // 
            this.ctrlPersonCarddWithFilter1.FilterEnabled = true;
            this.ctrlPersonCarddWithFilter1.Location = new System.Drawing.Point(12, 66);
            this.ctrlPersonCarddWithFilter1.Name = "ctrlPersonCarddWithFilter1";
            this.ctrlPersonCarddWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCarddWithFilter1.Size = new System.Drawing.Size(850, 560);
            this.ctrlPersonCarddWithFilter1.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD_DrivingLicenseManagement.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(715, 619);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 667);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonCarddWithFilter1);
            this.Controls.Add(this.lblFindPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFindPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFindPerson;
        private ctrlPersonCarddWithFilter ctrlPersonCarddWithFilter1;
        private System.Windows.Forms.Button btnClose;
    }
}