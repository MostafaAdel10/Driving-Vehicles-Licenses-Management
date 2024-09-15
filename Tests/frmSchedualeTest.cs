using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DrivingLicenseManagement
{
    public partial class frmSchedualeTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypeBusiness.enTestType _TestTypeID = clsTestTypeBusiness.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmSchedualeTest(int LocalDrivingLicenseApplicationID, clsTestTypeBusiness.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSchedualeTest_Load(object sender, EventArgs e)
        {
            ctrlSchedualeTest1.TestTypeID = _TestTypeID;
            ctrlSchedualeTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
