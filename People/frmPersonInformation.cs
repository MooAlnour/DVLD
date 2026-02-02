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
    public partial class Form1: Form
    {
        
        public Form1(int PersonID)
        {
            InitializeComponent();
            ucPersonDetails1.LoadPersonInfo(PersonID);
        }

        public Form1(string NationalNo)
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
