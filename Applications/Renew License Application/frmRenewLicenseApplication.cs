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

namespace DVLD.Applications.Renew_License_Application
{
    public partial class frmRenewLicenseApplication: Form
    {
        private int _LicenseID = -1;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.FilterFocus() ;
            llShowNewLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            btnSave.Enabled = false;
            lblIssueDate.Text = DateTime.Now.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblAAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID==-1)
            {
                return;
            }
            int DefaultValidity = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidity).ToString("d/MM/yyyy");
            lblLicenseFees.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAAppFees.Text)+ Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;


            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is not yet Expired , it will Expir on " + ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToString("d/MM/yyyy"), "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is not Active ,choose An Active License " , "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Renew the license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicense license = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text,clsGlobal.CurrentUser.UserID);

            if (license==null)
            {
                MessageBox.Show("Filed To Renew License !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRLAppID.Text = license.ApplicationID.ToString();
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
    }
}
