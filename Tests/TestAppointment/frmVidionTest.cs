using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.TestAppointment
{
    public partial class frmVisionTest: Form
    {
         private int _LocalDrivingApplicationID = -1;
        
        public frmVisionTest(int localDAppID)
        {
            InitializeComponent();
            _LocalDrivingApplicationID = localDAppID;
        }

        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ucScheduleTest1.LoadInfo(_LocalDrivingApplicationID,-1);
        }
    }
}
