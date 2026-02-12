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

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationTypes: Form
    {
        clsApplicationTypes clsApplication;

        private int _ApplicationTypeID;
        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblApplicationTypesID.Text = _ApplicationTypeID.ToString();

            clsApplication = clsApplicationTypes.Find(_ApplicationTypeID);
                if (clsApplication == null)
                {
                    return;
                }

                txtFees.Text = clsApplication.ApplicationFees.ToString();
                txtTitle.Text = clsApplication.ApplicationTypeTitle;

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsApplication.ApplicationFees = decimal.Parse( txtFees.Text.ToString());
            clsApplication.ApplicationTypeTitle = txtTitle.Text.ToString();
            if (clsApplication.Save())
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
                errorProvider1.SetError(txtFees, "Fees Cant be Empty");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

        }
        
        
    }
    
}
