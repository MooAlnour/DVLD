using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Business;

namespace DVLD.People
{
    public partial class frmManagePeople: Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void _RefreshPeopleList()
        {
            dgvAllPeople.DataSource = clsPerson.GetAllPeople();
        }

        private void _AddNewPerson()
        {
            frmAddEditPersonInfo frmAddEditPersonInfo = new frmAddEditPersonInfo();
            frmAddEditPersonInfo.ShowDialog();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet ! ","Not Ready!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void phToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Not Implemented Yet ! ", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow != null)
            {
                int personID = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);
                frmAddEditPersonInfo frmAddEditPersonInfo = new frmAddEditPersonInfo(personID);
                frmAddEditPersonInfo.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person is not deleted.");

            }
        }

        private void showDeatilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow != null)
            {
                int personID = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);
                frmPersonInformation frmPerson = new frmPersonInformation(personID);
                frmPerson.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
