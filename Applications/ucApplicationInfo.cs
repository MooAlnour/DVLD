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
using DVLD.People;

namespace DVLD.Applications
{
    public partial class ucApplicationInfo: UserControl
    {
        private int _ApplicationID;

       private clsApplications _Applications;
        public ucApplicationInfo(int applicationID)
        {
            InitializeComponent();
            _ApplicationID = applicationID;
        }
        public ucApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadAplicationInfoByAppID(int ID)
        {
            _Applications = clsApplications.FindBaseApplication(ID);
            if (_Applications == null)
            {
                MessageBox.Show("No Application with this ID = " + ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillApplicationInfo();
        }
        private void _FillApplicationInfo()
        {
            lblApplicationType.Text = _Applications.ApplicationTypeInfo.ApplicationTypeTitle;

            //Aplication Basic Info
            lblID.Text = _Applications.ApplicationID.ToString();
            lblStatus.Text = _Applications.StatusText;
            lblFees.Text = _Applications.PaidFees.ToString();
            lblAplicant.Text = _Applications.ApplicantFullName;
            lblDate.Text = _Applications.ApplicationDate.ToString("dd/MM/yyyy");
            lblStatusDate.Text = _Applications.LastStatusDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = _Applications.CreatedByUserInfo.UserName;
        }

        private void lnkPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
            frmShowPerson frmShow = new frmShowPerson(_Applications.ApplicantPersonID);
            frmShow.ShowDialog();
        
    }
    }
}
