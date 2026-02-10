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

namespace DVLD.Users
{
    public partial class frmListUsers: Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllUser;

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUserInfo frmAddEditUser = new frmAddEditUserInfo();
            frmAddEditUser.ShowDialog();
            _RefreshUsersList();
        }
        private void _RefreshUsersList()
        {
            dgvUsers.DataSource = _dtAllUser;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }
        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUser = clsUsers.GetAllUsers();
            dgvUsers.DataSource = _dtAllUser;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0) 
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 350;

            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshUsersList();
                }

                else
                    MessageBox.Show("Person is not deleted.");

            }
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmAddEditUserInfo frmAddEditUser = new frmAddEditUserInfo();
            frmAddEditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (cbIsActive.Visible = (cbFilterBy.Text == "IsActive"))
            {
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
                txtFilterValue.Visible = false;
            }
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterCulomn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID" :
                    FilterCulomn = "Person ID";
                    break;
                case "UserID":
                    FilterCulomn = "UserID";
                    break;

                case "IsActive":
                    FilterCulomn = "IsActive";
                    break;
                case "FullName":
                    FilterCulomn = "FullName";
                    break;
            }
            if (txtFilterValue.Text.Trim()==""&&FilterCulomn=="None")
            {
                _dtAllUser.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }



            if (FilterCulomn == "PersonID"&& FilterCulomn == "UserID")
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterCulomn, txtFilterValue.Text.Trim());
            else
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCulomn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUserInfo frmUpdata = new frmAddEditUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmUpdata.ShowDialog();
            frmListUsers_Load(null,null);
        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmShowUser form = new frmShowUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshUsersList();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmChangePassword.ShowDialog();
            _RefreshUsersList();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterCulomn = "IsActive";
            string FilterVallu= cbIsActive.Text;
            switch (FilterVallu)
            {
                case "All":
                    break;
                case "Yes":
                    FilterVallu = "1";
                    break;
                case "No":
                    FilterVallu = "0";
                    break;
            }


            if (  FilterVallu == "All")
                _dtAllUser.DefaultView.RowFilter = "";
            else 
                _dtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterCulomn, FilterVallu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin frm =new  frmLogin();
            frm.ShowDialog();
        }
    }
}
