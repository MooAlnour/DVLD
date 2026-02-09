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

namespace DVLD.Users
{
    public partial class ucUserDetails: UserControl
    {
        private int _UserID;
       
        clsUsers User;
        public ucUserDetails()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            User = clsUsers.FindByUserID(UserID);
            if (User == null)
            {
                MessageBox.Show("No User with this ID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            ucPersonDetails1.LoadPersonInfo(User.PersonID);
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();
            if (User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }
    }
}
