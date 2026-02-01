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
using System.Reflection;
using DVLD.Properties;
using System.IO;

namespace DVLD.People.Controls
{
    public partial class ucPersonDetails: UserControl
    {

        private int _PersonID;

        private clsPerson _Person;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ucPersonDetails()
        {
            InitializeComponent();

        }


        private void _ResetDefualtValues()
        {

            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
            pbGendor.Image = Resources.Man_32;
            llEditPersonInfo.Visible = false;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person==null)
            {
                _ResetDefualtValues();
                MessageBox.Show("No Person with this ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                _ResetDefualtValues();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lblPersonID.Text = PersonID.ToString();
            lblFullName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            llEditPersonInfo.Enabled = true;
            lblNationalNo.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            _LoadPersonIamage();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frmAddEditPersonInfo = new frmAddEditPersonInfo(PersonID);
            frmAddEditPersonInfo.ShowDialog();
            LoadPersonInfo(PersonID);
        }

        private void _LoadPersonIamage()
        {
            if (_Person.Gendor == 0)
                pbGendor.Image = Resources.Man_32;
            else
                pbGendor.Image = Resources.Woman_32;


            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
