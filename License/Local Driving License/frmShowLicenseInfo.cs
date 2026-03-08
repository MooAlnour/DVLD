using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.Local_Driving_License
{
    public partial class frmShowLicenseInfo: Form
    {
        private int _LicenseIID = -1;
        public frmShowLicenseInfo(int licenseIID)
        {
            InitializeComponent();
            _LicenseIID = licenseIID;
        }
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfoControl1.LoadData(_LicenseIID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
