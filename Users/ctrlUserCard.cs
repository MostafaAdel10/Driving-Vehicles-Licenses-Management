using DVLD_BusinessLayer;
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
    public partial class ctrlUserCard : UserControl
    {
        private clsUsersBusiness _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        private void _ResetUserInfo()
        {
            ctrlPersonCardd1.ResetPersonInfo();

            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }
        private void _FillUserInfo()
        {
            ctrlPersonCardd1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUsersBusiness.FindByUserID(UserID);
            if( _User == null )
            {
                _ResetUserInfo();

                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }
    }
}
