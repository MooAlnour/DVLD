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
    public partial class Form2: Form
    {
        int DriverID = -1;
        public Form2(int D)
        {
            InitializeComponent();
            DriverID = D;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ucLicensesHistory1.LoadInfoByPersonID(DriverID);
        }
    }
}
