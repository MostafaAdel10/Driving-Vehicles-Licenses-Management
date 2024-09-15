using DVLD_BusinessLayer;
using DVLD_DrivingLicenseManagement.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DrivingLicenseManagement
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnEyeIcon_Click(object sender, EventArgs e)
        {
            if (tbPassWord.PasswordChar == '*')
            {
                tbPassWord.PasswordChar = '\0';
                btnEyeIcon.Image = Image.FromFile(@"D:\Programing\Images Projects\Images DVLD\EyeCrossedIcon.png");
            }
            else
            {
                tbPassWord.PasswordChar = '*';
                btnEyeIcon.Image = Image.FromFile(@"D:\Programing\Images Projects\Images DVLD\EyeIcon.png");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //string HashedPassord = clsDataHelper.ComputHash(tbPassWord.Text.Trim());

            clsUsersBusiness User = clsUsersBusiness.FindByUsernameAndPassword(tbUserName.Text.Trim(), tbPassWord.Text.Trim());
            if (User != null)
            {
                if(CheckBoxRememberMe.Checked)
                {
                    //store username and password
                    //clsGlobal.RememperUserNameAndPassword(tbUserName.Text.Trim(), tbPassWord.Text.Trim());

                    //Windows Registry
                    clsGlobal.RememperUserNameAndPasswordToRegistry(tbUserName.Text.Trim(), tbPassWord.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    //clsGlobal.RememperUserNameAndPassword("", "");

                    //Windows Registry
                    clsGlobal.RememperUserNameAndPasswordToRegistry("", "");

                }

                //incase the user is not active
                if (!User.IsActive)
                {
                    tbUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.",
                        "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal.CurrentUser = User;
                this.Hide();
                MainMenu frm = new MainMenu(this);
                frm.ShowDialog();
            }
            else
            {
                tbUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Event viewer
                    clsTroubleshootSystem.StoreInEventViewerEventLogs($"Field Wrong Trials!"
                        ,clsTroubleshootSystem.enEventType.Warning);
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

            string UserName = "", Password = "";

            //if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            //{
            //    tbUserName.Text = UserName;
            //    tbPassWord.Text = Password;
            //    CheckBoxRememberMe.Checked = true;
            //}
            //else
            //    CheckBoxRememberMe.Checked = false;

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                tbUserName.Text = UserName;
                tbPassWord.Text = Password;
                CheckBoxRememberMe.Checked = true;
            }
            else
                CheckBoxRememberMe.Checked = false;
        }
    }
}
