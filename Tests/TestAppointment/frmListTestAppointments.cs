using DVLD.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.TestAppointment
{
    public partial class frmListTestAppointments: Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsManageTestType.enTestType _TestType = clsManageTestType.enTestType.VisionTest;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsManageTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;

        }

        private void LoadTitel()
        {
            switch (_TestType)
            {
                case clsManageTestType.enTestType.VisionTest:
                    {
                        lblTitel.Text = "Vision Test Appointments";
                        break;
                    }
                case clsManageTestType.enTestType.WrittenTest:
                    {
                        lblTitel.Text = "Written Test Appointments";
                        break;
                    }
                case clsManageTestType.enTestType.StreetTest:
                    {
                        lblTitel.Text = "Street Test Appointments";
                        break;
                    }
            }
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            LoadTitel();
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            dgvAppointments.DataSource = _dtLicenseTestAppointments;
            ucLocalDrivingApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            lblRecordsCount.Text = dgvAppointments.Rows.Count.ToString();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingApplication localDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_LocalDrivingLicenseApplicationID);

            if (localDrivingApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmVisionTest SicheudlTest = new frmVisionTest(_LocalDrivingLicenseApplicationID, _TestType);
            SicheudlTest.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointomentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmVisionTest visionTest = new frmVisionTest(_LocalDrivingLicenseApplicationID, _TestType, AppointomentID);
            visionTest.ShowDialog();
            frmVisionTestAppointments_Load(null, null);
        }

        private void teakTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointomentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest takeTest = new frmTakeTest(AppointomentID, _TestType);
            takeTest.ShowDialog();
        }
    }
}
