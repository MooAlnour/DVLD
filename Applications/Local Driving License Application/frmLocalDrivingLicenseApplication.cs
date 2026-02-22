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

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class frmLocalDrivingLicenseApplication: Form
    {
        private DataTable _dtLocalDrivingLicense = clsLocalDrivingApplication.GetAllLocalDrivingApplications();
        public frmLocalDrivingLicenseApplication()
        {
            InitializeComponent();
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
    }
}
