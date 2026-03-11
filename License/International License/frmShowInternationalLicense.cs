using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.International_License
{
    public partial class frmShowInternationalLicense: Form
    {
        int _LicenseID = -1;
        public frmShowInternationalLicense(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmShowInternationalLicense_Load(object sender, EventArgs e)
        {
            ucInternationalLicenseInfo1.LoadData(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
