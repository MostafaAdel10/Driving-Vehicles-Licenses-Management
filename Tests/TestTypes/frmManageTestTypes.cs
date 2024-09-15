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
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestTypeBusiness.GetAllTestTypes();
            ManageTestTypesGrid.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = ManageTestTypesGrid.Rows.Count.ToString();
            if(ManageTestTypesGrid.Rows.Count > 0 )
            {
                ManageTestTypesGrid.Columns[0].HeaderText = "ID";
                ManageTestTypesGrid.Columns[0].Width = 120;

                ManageTestTypesGrid.Columns[1].HeaderText = "Title";
                ManageTestTypesGrid.Columns[1].Width = 200;

                ManageTestTypesGrid.Columns[2].HeaderText = "Description";
                ManageTestTypesGrid.Columns[2].Width = 400;

                ManageTestTypesGrid.Columns[3].HeaderText = "Fees";
                ManageTestTypesGrid.Columns[3].Width = 100;
            }
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes frm = new frmEditTestTypes((clsTestTypeBusiness.enTestType)ManageTestTypesGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageTestTypes_Load(null, null);
        }
    }
}
