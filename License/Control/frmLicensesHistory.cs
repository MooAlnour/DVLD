using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Business;
using DVLD.License.Local_Driving_License;

namespace DVLD.Driver
{
    public partial class ucLicensesHistory: UserControl
    {
        int _DriverID = -1;
        clsDriverLicenses Driver;
        private DataTable _dtDriverLocalLicenseHistory;
        private DataTable _dtDriverInternationalLicenseHistory;

        public ucLicensesHistory()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicenseHistory = clsDriverLicenses.GetLicenses(_DriverID);
            dgvLocal.DataSource = _dtDriverLocalLicenseHistory;
            lblRecordsCountLocal.Text = dgvLocal.Rows.Count.ToString();
            if (dgvLocal.Rows.Count>0)
            {
                dgvLocal.Columns[0].HeaderText = "Lic.ID";
                dgvLocal.Columns[0].Width = 100;

                dgvLocal.Columns[1].HeaderText = "App.ID";
                dgvLocal.Columns[1].Width = 100;

                dgvLocal.Columns[2].HeaderText = "Class Name";
                dgvLocal.Columns[2].Width = 260;

                dgvLocal.Columns[3].HeaderText = "Issue Date";
                dgvLocal.Columns[3].Width = 130;

                dgvLocal.Columns[4].HeaderText = "Expiration Date";
                dgvLocal.Columns[4].Width = 130;

                dgvLocal.Columns[5].HeaderText = "Is Active";
                dgvLocal.Columns[5].Width = 90;

            }
        }

        private void _LoadInternaionalLicenseInfo()
        {
            _dtDriverInternationalLicenseHistory = clsDriverLicenses.GetLicenses(_DriverID);
            dgvInternational.DataSource = _dtDriverInternationalLicenseHistory;
            lblRecordsCountLocal.Text = dgvInternational.Rows.Count.ToString();
            if (dgvInternational.Rows.Count > 0)
            {
                dgvInternational.Columns[0].HeaderText = "Lic.ID";
                dgvInternational.Columns[0].Width = 100;

                dgvInternational.Columns[1].HeaderText = "App.ID";
                dgvInternational.Columns[1].Width = 100;

                dgvInternational.Columns[2].HeaderText = "Class Name";
                dgvInternational.Columns[2].Width = 260;

                dgvInternational.Columns[3].HeaderText = "Issue Date";
                dgvInternational.Columns[3].Width = 130;

                dgvInternational.Columns[4].HeaderText = "Expiration Date";
                dgvInternational.Columns[4].Width = 130;

                dgvInternational.Columns[5].HeaderText = "Is Active";
                dgvInternational.Columns[5].Width = 90;

            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            Driver = clsDriverLicenses.Find(_DriverID);

            if (Driver==null)
            {
                MessageBox.Show("There Is Driver With This ID :"+_DriverID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenseInfo();
            _LoadInternaionalLicenseInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            Driver = clsDriverLicenses.FindByPersonID(PersonID);
            if (Driver == null)
            {
                MessageBox.Show("There Is Driver With This ID :" + _DriverID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = Driver.DriverID;

            
            _LoadLocalLicenseInfo();
            _LoadInternaionalLicenseInfo();
        }

        public void Clear()
        {
            _dtDriverInternationalLicenseHistory.Clear();
            _dtDriverLocalLicenseHistory.Clear();
        }

        private void ucLicensesHistory_Load(object sender, EventArgs e)
        {

        }

        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void showLocalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocal.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
    }
}
