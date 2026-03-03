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
using DVLD.Globel_Class;

namespace DVLD.Tests.Control
{
    public partial class ucScheduleTest: UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enCreationMode { FirstTimeSchedule=0,RetakeTestSchedule=1};
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

     
        private clsManageTestType.enTestType _TestTypeID = clsManageTestType.enTestType.VisionTest;

      
        private clsLocalDrivingApplication _LocalDrivingApplication;
      
        private int _localDrivingApplicationID = -1;

        private int _TestAppointmentID = -1;
      
        private clsTestAppointment _TestAppointment;

    
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
                            gbTestTitel.Text = "Vision Test";
                            break;
                        }
                    case clsManageTestType.enTestType.WrittenTest:
                        {
                            gbTestTitel.Text = "Written Test";
                            break;
                        }
                    case clsManageTestType.enTestType.StreetTest:
                        {
                            gbTestTitel.Text = "Street Test";
                            break;
                        }

                }
            }
        }

        public ucScheduleTest( )
        {
            InitializeComponent();
        }
     
        public void LoadInfo(int LocalDrivingApplicationID ,int AppointmentID=-1)
        {
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _localDrivingApplicationID = LocalDrivingApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_localDrivingApplicationID);
           
            if (_LocalDrivingApplication==null)
            {
                MessageBox.Show("Error: No Local Driving License Application With this ID: "+_LocalDrivingApplication.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;
            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitel.Text = "Schedul Retake Test";
                lblRTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitel.Text = "Schedul Test";
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/0";
            }
            lblDLAppID.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LocalDrivingApplication.LicenseClassesInfo.ClassName;
            lblName.Text = _LocalDrivingApplication.PersonFullName;

            lblTrial.Text = _LocalDrivingApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            if (_Mode==enMode.AddNew)
            {
                lblTestFees.Text = clsManageTestType.Find(_TestTypeID).TestTypeFees.ToString();
                dtDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }

            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblRTotalFees.Text = (Convert.ToSingle(lblTestFees.Text) + Convert.ToSingle(lblRAppFees.Text)).ToString();

            if (_HandleActiveTestAppointmentConstraint()) return;

            if (_HandleAppointmentLockedConstraint())
                return;
            if (_HandlePrviousTestConstraint())
                return;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode==enMode.AddNew&&clsLocalDrivingApplication.IsThereAnActiveScheduledTest(_localDrivingApplicationID,_TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active Appointment for this Application";
                btnSave.Enabled = false;
                dtDate.Enabled = false;
                return false;

            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Text = "Person Already sat for the test, Appointment Loacked";
                dtDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            switch (TestType)
            {
                case clsManageTestType.enTestType.VisionTest :
                    lblUserMessage.Visible = false;
                    return true;

                case clsManageTestType.enTestType.WrittenTest:
                    if (!_LocalDrivingApplication.DoesPassTestType(clsManageTestType.enTestType.VisionTest))
                    {

                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtDate.Enabled = true;
                    }

                    return true;

                case clsManageTestType.enTestType.StreetTest:
                    if (!_LocalDrivingApplication.DoesPassTestType(clsManageTestType.enTestType.WrittenTest))
                    {

                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtDate.Enabled = true;
                    }

                    return true;
            }

            return true;
        }
        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.FindTestAppointmentInfoByID(_TestAppointmentID);
            if (_TestAppointment==null)
            {
                MessageBox.Show("Error: No Test Appointment With this ID: " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) > 0)
                dtDate.MinDate = DateTime.Now;
            else
                dtDate.MinDate = _TestAppointment.AppointmentDate;
            if (_TestAppointment.RetakeTestApplicationID == -1) 
            {
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
            }
            else
            {
                lblRAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitel.Text = "Schedule Retake Test";
                lblRTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }
        private bool _HandleRetakeApplication()
        {
            if (_Mode==enMode.AddNew&&_CreationMode==enCreationMode.RetakeTestSchedule)
            {
                clsApplications Application = new clsApplications();
                Application.ApplicantPersonID = _LocalDrivingApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _localDrivingApplicationID;
            _TestAppointment.AppointmentDate = dtDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTestFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
