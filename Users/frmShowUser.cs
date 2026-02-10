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
    public partial class frmShowUser: Form
    {
        private int _UserID;
        public frmShowUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmShowUser_Load(object sender, EventArgs e)
        {
            ucUserDetails1.LoadUserInfo(_UserID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
