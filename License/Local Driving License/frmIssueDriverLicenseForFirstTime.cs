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
using static DVLD.Business.clsLicense;

namespace DVLD.License
{
    public partial class frmIssueDriverLicenseForFirstTime: Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingApplication _clsLocalDrivingApplication;
        clsLicense Newlicense;
        clsDriverLicenses DriverLicenses;
        public frmIssueDriverLicenseForFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            txtNote.Focus();
            _clsLocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_LocalDrivingLicenseApplicationID);
           
            if (_clsLocalDrivingApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!_clsLocalDrivingApplication.PassedAllTests())
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _clsLocalDrivingApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ucLocalDrivingApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _clsLocalDrivingApplication.IssueLicenseforTheFirstTime(txtNote.Text, _clsLocalDrivingApplication.CreatedByUserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
