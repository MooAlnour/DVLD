using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD.DataAccess;

namespace DVLD.Business { 
    class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gendor { get; set; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }


        public clsPerson(){
            this.ID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gendor = 0;
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;

            this.NationalityCountryID = -1;

            this.ImagePath = "";

            Mode = enMode.AddNew;
        }
        private clsPerson(int ID, string FirstName, string SecondName, string ThirdName,string LastName,short Gendor,
            string Email, string Phone, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)

        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gendor = Gendor;
            this.Email = Email;
            this.Phone = Phone;
            this.Address =Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(this.FirstName,this.SecondName,this.ThirdName, this.LastName,this.Gendor, this.Email
                , this.Phone, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);
            return (this.ID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpDatePerson(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gendor, this.Email
                , this.Phone, this.Address, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();
            }
            return false;
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }
        public static clsPerson Find(int ID)
        {
            string FirstName = "", SecondName= "", ThirdName="", LastName = "", Email = "",
          Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = -1;
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByID(ID, ref  FirstName, ref  SecondName, ref  ThirdName, ref  LastName, ref  Gendor,
          ref  Email, ref  Phone, ref  Address, ref  DateOfBirth, ref  NationalityCountryID, ref  ImagePath))
                return new clsPerson(ID, FirstName, SecondName, ThirdName, LastName, Gendor,
                    Email, Phone, Address, DateOfBirth, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }



    }
}
