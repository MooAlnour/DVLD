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
using DVLD.Properties;
using System.IO;

namespace DVLD.Applications.International_License_Application.Control
{
    public partial class ucInternationalLicenseInfo: UserControl
    {
        int _InternationalLicenseID = -1;
        private clsInternationalLicense _License;

        public clsInternationalLicense SelectedInternationalLicenseInfo
        {
            get
            {
                return _License;
            }
        }
        public int InternationalLicenseID
        {
            get
            {
                return _InternationalLicenseID;
            }
        }
        public ucInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPicure.Image = Resources.Male_512;
            else
                pbPicure.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPicure.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadData(int LicenseID)
        {
            _License = clsInternationalLicense.Find(LicenseID);
            _InternationalLicenseID = LicenseID;
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _InternationalLicenseID.ToString(),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }
            lblAplicationID.Text = _License.ApplicationID.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblLicenseID.Text = _License.IssuedUsingLocalLicenseID.ToString();
            lblInterLacenseID.Text = _License.InternationalLicenseID.ToString();
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblIssueDate.Text = _License.IssueDate.ToString("dd / MMM / yyyy");
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd / MMM / yyyy");
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd / MMM / yyyy");
            LoadPersonImage();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
