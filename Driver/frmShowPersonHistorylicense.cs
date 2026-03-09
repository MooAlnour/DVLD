using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Driver
{
    public partial class frmShowPersonHistorylicense: Form
    {
        int _PersonID = -1;
        public frmShowPersonHistorylicense(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }
        public frmShowPersonHistorylicense()
        {
            InitializeComponent();
        }

        private void frmShowPersonHistorylicense_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ucPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ucPersonCardWithFilter1.FilterEnabled = false;
                ucLicensesHistory1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ucPersonCardWithFilter1.FilterEnabled = true;
                ucPersonCardWithFilter1.FilterFocus();
            }
            
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID==-1)
            {
                ucLicensesHistory1.Clear();
            }
            else
                ucLicensesHistory1.LoadInfoByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
