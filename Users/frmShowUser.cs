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
        public frmShowUser(int UserID)
        {
            InitializeComponent();
            ucUserDetails1.LoadUserInfo(UserID);
        }

        private void frmShowUser_Load(object sender, EventArgs e)
        {

        }
    }
}
