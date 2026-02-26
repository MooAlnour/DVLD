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
    public partial class frmVisionTestAppointments: Form
    {
        public enum enTestType { VisionTest = 0, WrittenTest = 1, StreetTest = 2 };

        private int _LocalDrivingApplicationID = -1;
        clsTestAppointment testAppointment;
        private DataTable _dtApp;
        public frmVisionTestAppointments(int localDrivingApplicationID)
        {
            InitializeComponent();
            _LocalDrivingApplicationID = localDrivingApplicationID;
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        { 
            
            _dtApp = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingApplicationID, (int)enTestType.VisionTest);

            ucLocalDrivingApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingApplicationID);
            lblRecordsCount.Text = dgvAppointments.Rows.Count.ToString();
        }
    }
}
