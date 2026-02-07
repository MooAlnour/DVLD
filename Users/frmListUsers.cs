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
        private static DataTable dtAllUser = clsUsers.GetAllUsers();

        private static DataTable dtUsers = dtAllUser.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "IsActive");

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUserInfo frmAddEditUser = new frmAddEditUserInfo();
            frmAddEditUser.ShowDialog();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = dtUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0) 
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 220;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 220;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 320;

                dgvUsers.Columns[3].HeaderText = "Is Active";
                dgvUsers.Columns[3].Width = 215;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
