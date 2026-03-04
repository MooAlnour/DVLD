using DVLD.Business;
using DVLD.Globel_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTakeTest: Form
    {
        int AppointomentID = -1;
        private clsManageTestType.enTestType _TestTypeID = clsManageTestType.enTestType.VisionTest;
        int TestID = -1;
        clsTest Test;
        public frmTakeTest(int appointomentID, clsManageTestType.enTestType testType)
        {
            InitializeComponent();
            AppointomentID = appointomentID;
            _TestTypeID = testType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ucScheduleTestTake1.TestType = _TestTypeID;
            ucScheduleTestTake1.LoadInfo(AppointomentID);


            if (ucScheduleTestTake1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            int TestID = ucScheduleTestTake1.TestID;

            if (TestID != -1)
            {
                Test = clsTest.Find(TestID);

                if (Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFaill.Checked = false;

                lblUserMessage.Enabled = true;
                rbFaill.Enabled = false;
                rbPass.Enabled = false;
            }
            else
                Test = new clsTest();


        }

     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Test.TestAppointmentID = AppointomentID;
            Test.TestResult = rbPass.Checked;
            if (Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
