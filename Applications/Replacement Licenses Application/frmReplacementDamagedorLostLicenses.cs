using DVLD.Business;
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
using static DVLD.Business.clsLicense;

namespace DVLD.Applications.Replacement_Licenses_Application
{
    public partial class frmReplacementDamagedorLostLicenses: Form
    {
        private int _LicenseID = -1;

        public frmReplacementDamagedorLostLicenses()
        {
            InitializeComponent();
        }

      
        private int _GetApplicationType()
        {
            if (rbDamagedLicens.Checked)
             return   (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
            else
               return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
        }

        private enIssueReason _GetIssueReason(){

            if (rbDamagedLicens.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }
        private void frmReplacementDamagedorLostLicenses_Load(object sender, EventArgs e)
        {
            
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicens.Checked = true;
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                return;
            }
            
            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is not Active ,choose An Active License ", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicense license = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), clsGlobal.CurrentUser.UserID);
            


            if (license == null)
            {
                MessageBox.Show("Filed To Renew License !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLRAppID.Text = license.ApplicationID.ToString();
            _LicenseID = license.LicenseID;
            lblRenewLicenseID.Text = _LicenseID.ToString();

            MessageBox.Show("License Renew Successufully", "Successufully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowNewLicenseInfo.Enabled = true;

        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo =
               new frmShowLicenseInfo(_LicenseID);
            showLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamagedLicens_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement for Damaged Licenses";
            this.Text = lblTitel.Text;
            lblAAppFees.Text = clsApplicationTypes.Find(_GetApplicationType()).ApplicationFees.ToString();
        }

        private void rbLostLicenses_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement for Lost Licenses";
            this.Text = lblTitel.Text;
            lblAAppFees.Text = clsApplicationTypes.Find(_GetApplicationType()).ApplicationFees.ToString();
        }
    }
}
