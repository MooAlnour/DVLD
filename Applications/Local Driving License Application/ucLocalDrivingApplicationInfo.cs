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
using DVLD.People;

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class ucLocalDrivingApplicationInfo: UserControl
    {
        private int  _LocalDrivingLicenseID = -1;
        private int _LicenseID;
        public int LocalDrivingApplicationID
        {
            get { return _LocalDrivingLicenseID; }
        }
        clsLocalDrivingApplication _LocalDrivingApplication;
        public ucLocalDrivingApplicationInfo()
        {
            InitializeComponent();
            
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingAppID)
        {
            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(LocalDrivingAppID);
            if (_LocalDrivingApplication == null)
            {
                MessageBox.Show("No Application with this ID = " + LocalDrivingAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillLocalDrivingApplicationInfo();
        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingApplicationID(ApplicationID);
            if (_LocalDrivingApplication == null)
            {
                MessageBox.Show("No Application with this ID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillLocalDrivingApplicationInfo();
        }

        private void _FillLocalDrivingApplicationInfo()
        {
            
            lblDLApplicationID.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingApplication.ApplicationDate.ToString("dd/MM/yyyy");
            ucApplicationInfo1.LoadAplicationInfoByAppID(_LocalDrivingApplication.ApplicationID);
            //Aplication Basic Info
            

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ucLocalDrivingApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void lblPassedTest_Click(object sender, EventArgs e)
        {

        }

       
    }
}
