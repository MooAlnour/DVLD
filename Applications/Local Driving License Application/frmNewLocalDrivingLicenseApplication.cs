using DVLD.Business;
using DVLD.Globel_Class;
using DVLD.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class frmNewLocalDrivingLicenseApplication: Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _localDrivingApplicationID = -1;
        int PersonSelected = -1;

        private clsLocalDrivingApplication _localDrivingApplication;

        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmNewLocalDrivingLicenseApplication(int localDrivingApplicationID)
        {
            InitializeComponent();
            _localDrivingApplicationID = localDrivingApplicationID;
            _Mode = enMode.Update;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {

                cbLicenseClass.Items.Add(row["ClassName"]);

            }
        }
        private void _ResetDefualtValues()
        {
            _FillLicenseClassesInComoboBox();

            if (_Mode==enMode.AddNew)
            {
                lblTitel.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _localDrivingApplication = new clsLocalDrivingApplication();
                tpApplicationInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToString("d/MM/yyyy");
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitel.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
                button1.Enabled = true;
            }
        }
        private   void _LoadData()
        {
            ucPersonCardWithFilter1.FilterEnabled = false;
            _localDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_localDrivingApplicationID);
            if (_localDrivingApplication==null)
            {
                MessageBox.Show(" No Application with ID = " + _localDrivingApplicationID);
                this.Close();
                return;
            }
            lblDLApplicationID.Text = _localDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            ucPersonCardWithFilter1.LoadPersonInfo(_localDrivingApplication.ApplicantPersonID);
            lblApplicationDate.Text = _localDrivingApplication.ApplicationDate.ToString();
            lblApplicationFees.Text = _localDrivingApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUsers.FindByUserID(_localDrivingApplication.CreatedByUserID).ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClasses.Find(_localDrivingApplication.LicenseClassID).ToString());
        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode==enMode.Update)
            {
                _LoadData();
            }
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            PersonSelected = obj;
        }

        //private void frmNewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        //{
        //    ucPersonCardWithFilter1.FilterFocus();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                button1.Enabled = true;
                tpApplicationInfo.Enabled = true;
                ucPersonCardWithFilter1.FilterEnabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ucPersonCardWithFilter1.PersonID != 0)
            {

                button1.Enabled = true;
                tpApplicationInfo.Enabled = true;
                ucPersonCardWithFilter1.FilterEnabled = false;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucPersonCardWithFilter1.FilterFocus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClasses.Find(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(ucPersonCardWithFilter1.PersonID, clsApplications.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            _localDrivingApplication.ApplicantPersonID = ucPersonCardWithFilter1.PersonID;
            _localDrivingApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _localDrivingApplication.ApplicationTypeID = 1;
            _localDrivingApplication.ApplicationDate = DateTime.Now;
            _localDrivingApplication.LastStatusDate = DateTime.Now;
            _localDrivingApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _localDrivingApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _localDrivingApplication.LicenseClassID = LicenseClassID;

            if (_localDrivingApplication.Save())
            {
                lblDLApplicationID.Text = _localDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
                lblTitel.Text = "";
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved");

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

        }
    }
}
