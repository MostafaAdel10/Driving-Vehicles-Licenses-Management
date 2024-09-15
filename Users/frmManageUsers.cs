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
    public partial class frmManageUsers : Form
    {
        public static DataTable _dtAllUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUsersBusiness.GetAllUsers();
            ManageUserGrid.DataSource = _dtAllUsers;

            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();

            ManageUserGrid.Columns[0].HeaderText = "User ID";
            ManageUserGrid.Columns[0].Width = 110;

            ManageUserGrid.Columns[1].HeaderText = "Person ID";
            ManageUserGrid.Columns[1].Width = 120;

            ManageUserGrid.Columns[2].HeaderText = "Full Name";
            ManageUserGrid.Columns[2].Width = 350;

            ManageUserGrid.Columns[3].HeaderText = "UserName";
            ManageUserGrid.Columns[3].Width = 120;

            ManageUserGrid.Columns[4].HeaderText = "Is Active";
            ManageUserGrid.Columns[4].Width = 120;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterColumn)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if(FilterValue== "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            else
            {
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

                lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            //Reset the filters in case nothing selected or filter value conains nothing.
            if(txtFilterValue.Text =="" || FilterColumn == "Non")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmManageUsers_Load(null,null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)ManageUserGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void AddUsertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)ManageUserGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)ManageUserGrid.CurrentRow.Cells[0].Value;

            if (clsUsersBusiness.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ChangePasswordtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = (int)ManageUserGrid.CurrentRow.Cells[0].Value;
            frmChangePassword Frm = new frmChangePassword(UserID);
            Frm.ShowDialog();
        }

        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void PhoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
