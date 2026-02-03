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

namespace DVLD.People.Controls
{
    public partial class ucPersonCardWithFilter: UserControl
    {

        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private int _PersonID = -1;

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get
            {
                return ucPersonDetails1.PersonID;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ucPersonDetails1.SelectedPersonInfo;
            }
        }


        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }



        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();

            FindNow();
        }
        public void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID" :
                    ucPersonDetails1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "National No":
                    ucPersonDetails1.LoadPersonInfo(txtFilterValue.Text);
                    break;
            }
            if (OnPersonSelected != null)
                // Raise the event with a parameter
                PersonSelected(ucPersonDetails1.PersonID);
        }
      
        private void ucPersonCardWithFilter_Load(object sender, EventArgs e)
        {
             
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
    }
}
