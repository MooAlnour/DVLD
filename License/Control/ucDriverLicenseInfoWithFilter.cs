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
using DVLD.People.Controls;

namespace DVLD.License.Control
{
    public partial class ucDriverLicenseInfoWithFilter: UserControl
    {
        private int _LicenseID = -1;

        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                groupBox1.Enabled = _FilterEnabled;
            }
        }

        public int LicenseID
        {
            get
            {
                return ucDriverLicenseInfoControl1.LicenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ucDriverLicenseInfoControl1.SelectedLicenseInfo;
            }
        }

        public ucDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void FilterFocus()
        {
            txtLicenseID.Focus();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ucDriverLicenseInfoControl1.LoadData(LicenseID);
            _LicenseID = ucDriverLicenseInfoControl1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);
            //Rais the Event with paramter 
        }

        private void ucDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtLicenseID.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }


            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                button1.PerformClick();
            }
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtLicenseID, null);
            }
        }
    }
}
