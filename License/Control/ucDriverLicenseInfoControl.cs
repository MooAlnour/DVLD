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

namespace DVLD.License.Control
{
    public partial class ucDriverLicenseInfoControl: UserControl
    {
        int _LicenseID = -1;
        private clsLicense _License;

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _License;
            }
        }
        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }
        public ucDriverLicenseInfoControl()
        {
            InitializeComponent();
        }

        private void LoadPersonImage(){
                if (_License.DriverInfo.PersonInfo.Gendor == 0)
                    pbPicure.Image = Resources.Man_32;
                else
                    pbPicure.Image = Resources.Woman_32;


            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPicure.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void LoadData(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);
            _LicenseID = LicenseID;
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDriverID.Text = _License.DriverID.ToString();
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblNotes.Text = _License.Notes == "" ? "No Note" : _License.Notes;
            lblIssueDate.Text = _License.IssueDate.ToString("dd / MMM / yyyy");
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblIssueReason.Text = _License.IssueReasonText;
            LoadPersonImage();
        }
    }
}
