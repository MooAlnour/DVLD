using DVLD.Business;
using DVLD.Globel_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddEditUserInfo: Form
    {

        private int _PersonID;
        clsUsers _Users;

        public frmAddEditUserInfo()
        {
            InitializeComponent();
            ucPersonCardWithFilter1.OnPersonSelected += _PersonIDSelected;

        }


      private  void _PersonIDSelected(int PersonID)
        {
            _PersonID = PersonID;
            MessageBox.Show(_PersonID.ToString());
        }
        private void _Save()
        {
            if (clsUsers.isUserExist(_PersonID))
            {
                MessageBox.Show("This PersonID already has an account.");
                return;
            }
            _Users.PersonID = _PersonID;
            _Users.UserName = txtUserName.Text.Trim();
            if (cbIsActive.Checked)
            {
                _Users.IsActive = true;
            }
            else
            {
                _Users.IsActive = false;
            }
            _Users.Password = txtPassword.Text.Trim();
            if (_Users.Save())
            {
                lblUserID.Text = _Users.UserID.ToString();

                MessageBox.Show("Data Saved Successfully.");
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                return;
            }

            if (txtPassword != txtConfirmPassword)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "the  Password is not match Format!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void frmAddEditUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
