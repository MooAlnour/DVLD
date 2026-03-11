using DVLD.Business;
using DVLD.Driver;
using DVLD.License.International_License;
using DVLD.License.Local_Driving_License;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD.Applications.Detain_License_Application
{
    public partial class frmListDetainLicense: Form
    {
        private DataTable _dtListDetainLicense;

        public frmListDetainLicense()
        {
            InitializeComponent();
        }

        private void frmListDetainLicense_Load(object sender, EventArgs e)
        {
            _dtListDetainLicense = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainLicense.DataSource = _dtListDetainLicense;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvDetainLicense.Rows.Count.ToString();
            if (dgvDetainLicense.Rows.Count > 0)
            {
                dgvDetainLicense.Columns[0].HeaderText = "D.ID";
                dgvDetainLicense.Columns[0].Width = 130;

                dgvDetainLicense.Columns[1].HeaderText = "L.ID";
                dgvDetainLicense.Columns[1].Width = 140;

                dgvDetainLicense.Columns[2].HeaderText = "D.Date";
                dgvDetainLicense.Columns[2].Width = 150;

                dgvDetainLicense.Columns[3].HeaderText = "Is Released";
                dgvDetainLicense.Columns[3].Width = 120;

                dgvDetainLicense.Columns[4].HeaderText = "Fine Fees";
                dgvDetainLicense.Columns[4].Width = 150;

                dgvDetainLicense.Columns[5].HeaderText = "Release Date";
                dgvDetainLicense.Columns[5].Width = 140;

                dgvDetainLicense.Columns[6].HeaderText = "N.No";
                dgvDetainLicense.Columns[6].Width = 100;

                dgvDetainLicense.Columns[7].HeaderText = "Full Name";
                dgvDetainLicense.Columns[7].Width = 180;

                dgvDetainLicense.Columns[8].HeaderText = "Release App.ID";
                dgvDetainLicense.Columns[8].Width = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApp frmDetain = new frmDetainLicenseApp();
            frmDetain.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find((int)dgvDetainLicense.CurrentRow.Cells[1].Value);

            frmShowPersonHistorylicense frmShow = new frmShowPersonHistorylicense(license.DriverInfo.PersonID);
            frmShow.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find((int)dgvDetainLicense.CurrentRow.Cells[1].Value);
            frmShowPerson frmShow = new frmShowPerson(license.DriverInfo.PersonID);
            frmShow.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find((int)dgvDetainLicense.CurrentRow.Cells[1].Value);
            if (license!=null)
            {
                frmShowLicenseInfo frmShow = new frmShowLicenseInfo((int)dgvDetainLicense.CurrentRow.Cells[1].Value);
                frmShow.ShowDialog();
            }
            else {
                frmShowInternationalLicense frmShowd = new frmShowInternationalLicense((int)dgvDetainLicense.CurrentRow.Cells[1].Value);
                frmShowd.ShowDialog();
            }

                
        }

        private void btnRleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frmRelease = new frmReleaseDetainLicense();
            frmRelease.Show();
        }

        private void rleaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frmRelease = new frmReleaseDetainLicense((int)dgvDetainLicense.CurrentRow.Cells[1].Value);
            frmRelease.Show();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;
            }

            if (cbFilterBy.Text == "None")
            {
                cbIsReleased.Visible = false;
            }
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtListDetainLicense.DefaultView.RowFilter = "";
            else
                _dtListDetainLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtListDetainLicense.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
            }

            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {

                case "D.ID" :
                    FilterColumn = "DetainID";
                    break;

                case "License ID":
                    FilterColumn = "LicenseID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                //case "Is Released":
                //    FilterColumn = "IsReleased";
                //    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtListDetainLicense.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDetainLicense.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "DetainID" || FilterColumn == "LicenseID")

                _dtListDetainLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtListDetainLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvDetainLicense.Rows.Count.ToString();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            rleaseLicenseToolStripMenuItem.Enabled=!(bool)dgvDetainLicense.CurrentRow.Cells[3].Value;
        }
    }
}
