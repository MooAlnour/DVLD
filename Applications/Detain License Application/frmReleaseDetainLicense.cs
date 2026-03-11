using DVLD.Business;
using DVLD.Driver;
using DVLD.Globel_Class;
using DVLD.License.Local_Driving_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Detain_License_Application
{
    public partial class frmReleaseDetainLicense: Form
    {
        int DetainID = -1;
        public frmReleaseDetainLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainLicense(int LicenseID)
        {
            InitializeComponent();

            DetainID = LicenseID;
            ucDriverLicenseInfoWithFilter1.LoadLicenseInfo(DetainID);
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void frmReleaseDetainLicense_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.FilterFocus();
            llShowNewLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            lblDetainDate.Text = DateTime.Now.ToString("d / MM / yyyy");
            btnRelease.Enabled = false;
            }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                return;
            }


            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License I Not Detained , Choose anther one", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

    
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            lblCreatedBy.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;

            lblDetainID.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblFineFees.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblFineFees.Text.Trim()) + Convert.ToInt32(lblApplicationFees.Text.Trim())).ToString();
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;
            bool IsReleased = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            MessageBox.Show("License Release Successufully", "Successufully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            llShowNewLicenseInfo.Enabled = true;
            btnRelease.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;

        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frmShow = new frmShowLicenseInfo(DetainID);
            frmShow.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonHistorylicense frmShow = new frmShowPersonHistorylicense(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmShow.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
