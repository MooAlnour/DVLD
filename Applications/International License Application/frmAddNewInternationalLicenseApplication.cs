using DVLD.Business;
using DVLD.Driver;
using DVLD.Globel_Class;
using DVLD.License.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.International_License_Application
{
    public partial class frmAddNewInternationalLicenseApplication: Form
    {
        int _InternationalLicenseID = -1;
        clsInternationalLicense internationalLicense;
        public frmAddNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmAddNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.FilterFocus();
            llShowNewLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            btnSave.Enabled = false;
            lblIssueDate.Text = DateTime.Now.ToString("d / MM / yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd / MM / yyyy");
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLoaclLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);


            if (SelectedLicenseID == -1)
            {
                return;
            }

            if (ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3) 
            {
                MessageBox.Show("Selected License Should be Class 3 ,choose anther one", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is not Active ,choose An Active License ", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            int ActiveInternationaLicense = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationaLicense != -1) 
            {
                MessageBox.Show("Person Already has an Active International License With ID ="+internationalLicense.InternationalLicenseID.ToString(),"Not Allowed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            btnSave.Enabled = true;
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicense frmShow = new frmShowInternationalLicense(_InternationalLicenseID);
            frmShow.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            internationalLicense = new clsInternationalLicense();
            internationalLicense.ApplicationID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ApplicationID;
            internationalLicense.ApplicationDate = DateTime.Now;
            internationalLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            internationalLicense.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewInternationalLicense).ApplicationFees;
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.ApplicantPersonID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;


            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.DriverID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ucDriverLicenseInfoWithFilter1.LicenseID;



            if (!internationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
               
            lblILLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            lblILAppID.Text = internationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = internationalLicense.InternationalLicenseID;
            MessageBox.Show("License Issue Successufully", "Successufully", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnSave.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowNewLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmShowPersonHistorylicense frmShowPerson = new frmShowPersonHistorylicense(internationalLicense.ApplicantPersonID);
            frmShowPerson.ShowDialog();
        }
    }
}
