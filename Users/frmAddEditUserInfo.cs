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

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID;
        clsUsers User;

        public frmAddEditUserInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }


        public frmAddEditUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew) 
            {
                this.Text = "Add New User";
                lblTitle.Text = "Add New User";
                User = new clsUsers();
                tabPage2.Enabled = false;
                ucPersonCardWithFilter1.Focus();
            }
            else
            {
                this.Text = "Update User";
                lblTitle.Text = "Update User";
                tabPage2.Enabled = true;
            }
            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            lblUserID.Text = "[????]";

        }

        private void _LoadData()
        {
            User = clsUsers.FindByUserID(_UserID);
            ucPersonCardWithFilter1.FilterEnabled = false;
            if (User==null)
            {
                MessageBox.Show("No User With This ID" + User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            txtUserName.Text = User.UserName;
            txtConfirmPassword.Text = User.Password;
            txtPassword.Text = User.Password;
            lblUserID.Text = User.UserID.ToString();
            cbIsActive.Checked = User.IsActive;
            ucPersonCardWithFilter1.LoadPersonInfo(User.PersonID);
        }

        private void frmAddEditUserInfo_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode==enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            User.UserName = txtUserName.Text;
            User.Password = txtPassword.Text;
            User.PersonID = ucPersonCardWithFilter1.PersonID;
            User.IsActive = cbIsActive.Checked;

            if (User.Save())
            {
                this.Text = "Update User";
                lblTitle.Text = "Update User";
                lblUserID.Text = User.UserID.ToString();
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tabPage2.Enabled = true;
                btnSave.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            }

            if (ucPersonCardWithFilter1.PersonID != 0)
                {
               
                if (clsUsers.IsUserExistbyPersonID(ucPersonCardWithFilter1.PersonID))
                    {
                        
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ucPersonCardWithFilter1.FilterFocus();

                }
                else
                {
                    tabPage2.Enabled = true;
                    btnSave.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucPersonCardWithFilter1.FilterFocus();
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim()!= txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        
        }
    }
}
