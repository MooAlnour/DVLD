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
            comboBox1.DisplayMember = "ID";

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
    }
}
