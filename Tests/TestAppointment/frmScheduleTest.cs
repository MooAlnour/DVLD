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

namespace DVLD.Tests.TestAppointment
{
    public partial class frmVisionTest: Form
    {
         private int _LocalDrivingApplicationID = -1;
        private clsManageTestType.enTestType _TestType = clsManageTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmVisionTest(int localDAppID,clsManageTestType.enTestType testType,int testAppointments=-1)
        {
            InitializeComponent();
            _LocalDrivingApplicationID = localDAppID;
            _TestType = testType;
            _AppointmentID = testAppointments;
        }

        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ucScheduleTest1.TestType = _TestType;
            ucScheduleTest1.LoadInfo(_LocalDrivingApplicationID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
