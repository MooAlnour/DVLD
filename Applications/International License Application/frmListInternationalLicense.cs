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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.International_License_Application
{
    public partial class frmListInternationalLicense: Form
    {
        private DataTable _dtInternationalDrivingLicense;

        public frmListInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicense_Load(object sender, EventArgs e)
        {
            _dtInternationalDrivingLicense = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternational.DataSource = _dtInternationalDrivingLicense;
            cbFilterBy.SelectedIndex = 0;

            lblRecordsCount.Text = dgvInternational.Rows.Count.ToString();

            if (dgvInternational.Rows.Count > 0)
            {
                dgvInternational.Columns[0].HeaderText = "Int.License ID";
                dgvInternational.Columns[0].Width = 130;

                dgvInternational.Columns[1].HeaderText = "Application ID";
                dgvInternational.Columns[1].Width = 140;

                dgvInternational.Columns[2].HeaderText = "Driver ID";
                dgvInternational.Columns[2].Width = 130;

                dgvInternational.Columns[3].HeaderText = "L.License ID";
                dgvInternational.Columns[3].Width = 130;

                dgvInternational.Columns[4].HeaderText = "Issue Date";
                dgvInternational.Columns[4].Width = 150;

                dgvInternational.Columns[5].HeaderText = "Expiration Date";
                dgvInternational.Columns[5].Width = 150;

                dgvInternational.Columns[6].HeaderText = "Is Active";
                dgvInternational.Columns[6].Width = 120;
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense clsInternational=clsInternationalLicense.Find((int)dgvInternational.CurrentRow.Cells[0].Value);

            frmShowPerson frmShow = new frmShowPerson(clsInternational.ApplicantPersonID);
            frmShow.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense clsInternational = clsInternationalLicense.Find((int)dgvInternational.CurrentRow.Cells[0].Value);

            frmShowInternationalLicense frmShow = new frmShowInternationalLicense(clsInternational.InternationalLicenseID);
            frmShow.ShowDialog();
        }

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense clsInternational = clsInternationalLicense.Find((int)dgvInternational.CurrentRow.Cells[0].Value);

            frmShowPersonHistorylicense frmShoww = new frmShowPersonHistorylicense(clsInternational.ApplicantPersonID);
            frmShoww.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "IsActive")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
            }

            if (cbFilterBy.Text == "None")
            {
                cbIsActive.Visible = false;
            }
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
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

                case "I.D.L.AppID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalDrivingLicense.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvInternational.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "InternationalLicenseID"|| FilterColumn == "ApplicationID" || FilterColumn == "DriverID")

                _dtInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvInternational.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

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
                _dtInternationalDrivingLicense.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtInternationalDrivingLicense.Rows.Count.ToString();


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frmAddNew = new frmAddNewInternationalLicenseApplication();
            frmAddNew.ShowDialog();
        }
    }
}
