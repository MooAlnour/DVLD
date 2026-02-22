using DVLD.Applications;
using DVLD.Applications.Local_Driving_License_Application;
using DVLD.Globel_Class;
using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Form1: Form
    {
        frmLogin _frmLogin;
        public Form1(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople listPeople = new frmListPeople();
            listPeople.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frmList = new frmListUsers();
            frmList.ShowDialog();
        }

        private void logeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void currentAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUser frmShow = new frmShowUser(clsGlobal.CurrentUser.UserID);
            frmShow.ShowDialog();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frmChangePassword.ShowDialog();
        }

        private void manageApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplication frmManage = new frmManageApplication();
            frmManage.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestType testType = new frmManageTestType();
            testType.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frmNewLocal = new frmNewLocalDrivingLicenseApplication();
            frmNewLocal.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplication frmLocalDriving = new frmLocalDrivingLicenseApplication();
            frmLocalDriving.ShowDialog();
        }
    }
}
