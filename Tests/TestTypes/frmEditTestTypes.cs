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

namespace DVLD.Tests.TestTypes
{
    public partial class frmEditTestTypes: Form
    {
        //public enum enMode { AddNew = 0, Update = 1 };
        //public enMode Mode = enMode.AddNew;

        private clsManageTestType.enTestType _TestTypeID =clsManageTestType.enTestType.VisionTest;
      private clsManageTestType clsTestType;

        public frmEditTestTypes(clsManageTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            lblTestTypesID.Text = Convert.ToInt64(_TestTypeID).ToString();

            clsTestType = clsManageTestType.Find(_TestTypeID);
            if (clsTestType != null)
            {
                txtFees.Text = clsTestType.TestTypeFees.ToString();
                txtTitle.Text = clsTestType.TestTypeTitle;
                txtDescription.Text = clsTestType.TestTypeDescription;
            }
            else
            {
                this.Close();
                return;
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestType.TestTypeFees = Convert.ToSingle(txtFees.Text.ToString());
            clsTestType.TestTypeTitle = txtTitle.Text.Trim();
            clsTestType.TestTypeDescription = txtDescription.Text.Trim();
            if (clsTestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title Cant be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees Cant be Empty");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

            if (!clsValidatoin.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description Cant be Empty");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }
    }
}
