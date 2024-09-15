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
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable dtAllApplicationTypes;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dtAllApplicationTypes = clsApplicationTypesBusiness.GetAllApplicationTypes();
            ManageApplicationTypesGrid.DataSource = dtAllApplicationTypes;
            lblRecordsCount.Text = dtAllApplicationTypes.Rows.Count.ToString();

            if (dtAllApplicationTypes.Rows.Count > 0)
            {
                ManageApplicationTypesGrid.Columns[0].HeaderText = "ID";
                ManageApplicationTypesGrid.Columns[0].Width = 110;

                ManageApplicationTypesGrid.Columns[1].HeaderText = "Title";
                ManageApplicationTypesGrid.Columns[1].Width = 400;

                ManageApplicationTypesGrid.Columns[2].HeaderText = "Fees";
                ManageApplicationTypesGrid.Columns[2].Width = 100;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)ManageApplicationTypesGrid.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationTypes_Load(null, null);
        }
    }
}
