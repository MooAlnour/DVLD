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

namespace DVLD.Applications.Application_Types
{
    public partial class frmDriver: Form
    {
        private static DataTable _dtDriver = clsDriverLicenses.GetAllDriverLicenses();
        public frmDriver()
        {
            InitializeComponent();
        }

        private void frmDriver_Load(object sender, EventArgs e)
        {
            dgvDriverLicenses.DataSource = _dtDriver;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvDriverLicenses.Rows.Count.ToString();

            if (dgvDriverLicenses.Rows.Count > 0) 
            {
                dgvDriverLicenses.Columns[0].HeaderText = "Driver ID";
                dgvDriverLicenses.Columns[0].Width = 140;

                dgvDriverLicenses.Columns[1].HeaderText = "Person ID";
                dgvDriverLicenses.Columns[1].Width = 140;

                dgvDriverLicenses.Columns[2].HeaderText = "National No";
                dgvDriverLicenses.Columns[2].Width = 120;

                dgvDriverLicenses.Columns[3].HeaderText = "Full Name";
                dgvDriverLicenses.Columns[3].Width = 290;

                dgvDriverLicenses.Columns[4].HeaderText = "Date";
                dgvDriverLicenses.Columns[4].Width = 120;

                dgvDriverLicenses.Columns[5].HeaderText = "Active Licenses";
                dgvDriverLicenses.Columns[5].Width = 120;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Notional No":
                    FilterColumn = "NationalNo";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Active Licenses":
                    FilterColumn = "NumberOfActiveLicenses";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDriver.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDriverLicenses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DriverID" || FilterColumn == "PersonID") 
                //in this case we deal with integer not string.

                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDriver.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvDriverLicenses.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
    }
}
