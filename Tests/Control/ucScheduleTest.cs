using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Business;

namespace DVLD.Tests.Control
{
    public partial class ucScheduleTest: UserControl
    {
        int TestTypeID = -1;
        int localDrivingApplicationID = -1;
        clsTestAppointment _TestAppointment;
        public ucScheduleTest(int testTypeID, int localDrivingApplicationID)
        {
            InitializeComponent();
            TestTypeID = testTypeID;
            this.localDrivingApplicationID = localDrivingApplicationID;
        }
        private void ucScheduleTest_Load(object sender, EventArgs e)
        {
            if (TestTypeID==1)
            {
                groupBox1.Text = "Vision Test";
                lblFees.Text = 10.ToString();

            }

        }
    }
}
