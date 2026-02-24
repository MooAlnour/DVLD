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
using System.Xml.Linq;

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class frmLocalDrivingLicenseApplication: Form
    {
        private DataTable _dtLocalDrivingLicense = clsLocalDrivingApplication.GetAllLocalDrivingApplications();
        public frmLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        private void _Reset()
        {
            dgvLocalDrivingLicense.DataSource = _dtLocalDrivingLicense;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
        }
        private void frmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            dgvLocalDrivingLicense.DataSource = _dtLocalDrivingLicense;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
            if (dgvLocalDrivingLicense.Rows.Count > 0)
            {

                dgvLocalDrivingLicense.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicense.Columns[0].Width = 100;

                dgvLocalDrivingLicense.Columns[1].HeaderText = "Class Name";
                dgvLocalDrivingLicense.Columns[1].Width = 220;


                dgvLocalDrivingLicense.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicense.Columns[2].Width = 100;

                dgvLocalDrivingLicense.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicense.Columns[3].Width = 240;


                dgvLocalDrivingLicense.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicense.Columns[4].Width = 120;

                dgvLocalDrivingLicense.Columns[5].HeaderText = "Passed Test";
                dgvLocalDrivingLicense.Columns[5].Width = 100;

                dgvLocalDrivingLicense.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicense.Columns[6].Width = 100;
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "Notional No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLocalDrivingLicense.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
            }
            if (FilterColumn == "LocalDrivingLicenseApplicationID")

                _dtLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmNewLocal = new frmNewLocalDrivingLicenseApplication();
            frmNewLocal.ShowDialog();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ID = (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value;
              
            Form12 form = new Form12(ID);
            form.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvLocalDrivingLicense.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                int LocalDrivingApplicationID = (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value;
                clsLocalDrivingApplication localDrivingApplication = 
                    clsLocalDrivingApplication.FindByLocalDrivingApplicationID(LocalDrivingApplicationID);

                //Perform Delele and refresh
                if (localDrivingApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplication_Load(null,null);
                }

                else
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
