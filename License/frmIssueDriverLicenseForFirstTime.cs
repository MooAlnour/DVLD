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

namespace DVLD.License
{
    public partial class frmIssueDriverLicenseForFirstTime: Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsLocalDrivingApplication _clsLocalDrivingApplication;
        public frmIssueDriverLicenseForFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ucLocalDrivingApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _clsLocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(_LocalDrivingLicenseApplicationID);

        }
    }
}
