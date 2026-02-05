using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPerson: Form
    {
        
        public frmShowPerson(int PersonID)
        {
            InitializeComponent();
            ucPersonDetails1.LoadPersonInfo(PersonID);
        }

        public frmShowPerson(string NationalNo)
        {
            InitializeComponent();
            ucPersonDetails1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
