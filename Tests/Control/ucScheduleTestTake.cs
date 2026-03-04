using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Business;

namespace DVLD.Tests.Control
{
    public partial class ucScheduleTestTake: UserControl
    {
        private clsLocalDrivingApplication _LocalDrivingApplication;
        private int _TestAppointmentID = -1;
        private int _TestID = -1;

        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get {return _TestID; }
        }

        private clsTestAppointment _TestAppointment;

        private clsManageTestType.enTestType _TestTypeID = clsManageTestType.enTestType.VisionTest;
        public clsManageTestType.enTestType TestType
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsManageTestType.enTestType.VisionTest:
                        {
                            gbTakeTest.Text = "Vision Test";
                            break;
                        }
                    case clsManageTestType.enTestType.WrittenTest:
                        {
                            gbTakeTest.Text = "Written Test";
                            break;
                        }
                    case clsManageTestType.enTestType.StreetTest:
                        {
                            gbTakeTest.Text = "Street Test";
                            break;
                        }

                }
            }
        }
        public ucScheduleTestTake()
        {
            InitializeComponent();
            
        }
        public void LoadInfo(int AppointmentID)
        {
            _TestAppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointment.FindTestAppointmentInfoByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_TestAppointment.LocalDrivingLicenseApplicationID);

            if (_LocalDrivingApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestID = _TestAppointment.TestID;

            lblTestDate.Text = _TestAppointment.AppointmentDate.ToString("dd,M,yyyy");
            lblDLAppID.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LocalDrivingApplication.LicenseClassesInfo.ClassName;
            lblName.Text = _LocalDrivingApplication.PersonFullName;

            lblTrial.Text = _LocalDrivingApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

        }


    }
}
