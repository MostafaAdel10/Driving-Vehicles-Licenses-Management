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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DVLD_DrivingLicenseManagement
{
    public partial class ManagePeople : Form
    {
        private static DataTable _dtAllPeople = clsPeopleBusiness.GetAllPeople();

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
            "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName",
            "Phone", "Email");

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPeopleBusiness.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
            "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName",
            "Phone", "Email");

            ManagePeopleGrid.DataSource = _dtPeople;
            lblRecordsCount.Text = ManagePeopleGrid.Rows.Count.ToString();
        }

        public ManagePeople()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            ManagePeopleGrid.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = ManagePeopleGrid.Rows.Count.ToString();

            if (ManagePeopleGrid.Rows.Count > 0)
            {

                ManagePeopleGrid.Columns[0].HeaderText = "Person ID";
                ManagePeopleGrid.Columns[0].Width = 110;

                ManagePeopleGrid.Columns[1].HeaderText = "National No.";
                ManagePeopleGrid.Columns[1].Width = 120;


                ManagePeopleGrid.Columns[2].HeaderText = "First Name";
                ManagePeopleGrid.Columns[2].Width = 120;

                ManagePeopleGrid.Columns[3].HeaderText = "Second Name";
                ManagePeopleGrid.Columns[3].Width = 140;


                ManagePeopleGrid.Columns[4].HeaderText = "Third Name";
                ManagePeopleGrid.Columns[4].Width = 120;

                ManagePeopleGrid.Columns[5].HeaderText = "Last Name";
                ManagePeopleGrid.Columns[5].Width = 120;

                ManagePeopleGrid.Columns[6].HeaderText = "Gendor";
                ManagePeopleGrid.Columns[6].Width = 120;

                ManagePeopleGrid.Columns[7].HeaderText = "Date Of Birth";
                ManagePeopleGrid.Columns[7].Width = 140;

                ManagePeopleGrid.Columns[8].HeaderText = "Nationality";
                ManagePeopleGrid.Columns[8].Width = 120;


                ManagePeopleGrid.Columns[9].HeaderText = "Phone";
                ManagePeopleGrid.Columns[9].Width = 120;


                ManagePeopleGrid.Columns[10].HeaderText = "Email";
                ManagePeopleGrid.Columns[10].Width = 170;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = ManagePeopleGrid.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = ManagePeopleGrid.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)ManagePeopleGrid.CurrentRow.Cells[0].Value;
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void AddPersontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)ManagePeopleGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person " +
                "[" + ManagePeopleGrid.CurrentRow.Cells[0].Value + "]", "Confirm Delete",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPeopleBusiness.DeletePerson((int)ManagePeopleGrid.CurrentRow.Cells[0].Value))
                {
                    
                    MessageBox.Show("Person Deleted Successfully.", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        private void btnAddPersonal_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdatePerson();
            frm1.ShowDialog();
            _RefreshPeoplList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ManagePeopleGrid_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)ManagePeopleGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

    }
    
}
