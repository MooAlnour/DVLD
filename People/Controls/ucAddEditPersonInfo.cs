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
using System.Diagnostics.Contracts;

namespace DVLD.People
{
    public partial class ucAddEditPersonInfo: UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public event EventHandler CloseRequested;


        public int _PersonID { get; set; }
        clsPerson _Person;

        
        public ucAddEditPersonInfo()
        {
            InitializeComponent();
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }

        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 0;

            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Mode = enMode.Update;
            _Person = clsPerson.Find(_PersonID);
            if (_Person==null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                //this.Close();

                return;
            }
            lblMode.Text = "Edit Person ID = " + _PersonID;
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
            if (rbFemale.Checked)
            {
                _Person.Gendor = 1;
            }
            else
                _Person.Gendor = 0;
            if (_Person.ImagePath != "")
            {
                pictureBox3.Load(_Person.ImagePath);
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

                pictureBox3.Load(selectedFilePath);
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox3.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void ucAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void label7_Click(object sender, EventArgs e)
        {

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

            if (pictureBox3.ImageLocation != null)
                _Person.ImagePath = pictureBox3.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _Person.ID;
            lblPersonID.Text = _Person.ID.ToString();
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
