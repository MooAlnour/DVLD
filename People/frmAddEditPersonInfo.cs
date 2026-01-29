using DVLD.Business;
using DVLD.Properties;
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
    public partial class frmAddEditPersonInfo : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

     
        private int _PersonID = -1;

         clsPerson _Person;

        public frmAddEditPersonInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditPersonInfo(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }


        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
                lblMode.Text = "Update Person";

            if (rbFemale.Checked)
            
                pbPersonImage.Image = Resources.Female_512;
            else
                pbPersonImage.Image = Resources.Male_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Sudan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rbMale.Checked = true;
        }


        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

         
            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();
                return;
            }
            lblMode.Text = "Edit Person ID = " + _PersonID.ToString();
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
                rbFemale.Checked = true;


            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            llRemoveImage.Visible = (_Person.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);
        }


        private void lnklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPersonImage.Load(selectedFilePath);
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountry.Text).ID;

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            _Person.NationalityCountryID = CountryID;
            if (rbFemale.Checked)
            {
                _Person.Gendor = 1;
            }
            else
                _Person.Gendor = 0;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPersonInfo_Load_1(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
    }
}
