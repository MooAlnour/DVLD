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
    public partial class frmDetainLicenseApp: Form
    {
        int _DetainID = -1;
        clsDetainedLicense detainedLicense;
        public frmDetainLicenseApp()
        {
            InitializeComponent();
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                btnSave.PerformClick();
            }
        }

        private void frmDetainLicenseApp_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.FilterFocus();
            llShowNewLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            lblDetainDate.Text = DateTime.Now.ToString("d / MM / yyyy");
            btnSave.Enabled = false;
           lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
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

            if (clsDetainedLicense.IsLicenseDetained(SelectedLicenseID))
            {
                MessageBox.Show("Selected License I Already Detained , Choose anther one", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnSave.Enabled = true;
            txtFees.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(float.Parse(txtFees.Text.Trim()), clsGlobal.CurrentUser.UserID);

            if (_DetainID==-1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = detainedLicense.DetainID.ToString();

            MessageBox.Show("License Detain Successufully", "Successufully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowNewLicenseInfo.Enabled = true;
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frmShow = new frmShowLicenseInfo(_DetainID);
            frmShow.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonHistorylicense frmShow = new frmShowPersonHistorylicense(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmShow.ShowDialog();
        }
    }
}
