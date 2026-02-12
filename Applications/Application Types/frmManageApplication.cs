using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.Application_Types;
using DVLD.Business;
namespace DVLD.Applications
{
    public partial class frmManageApplication: Form
    {
        private DataTable _dtManageApilcation;
        public frmManageApplication()
        {
            InitializeComponent();
        }
       
       private void Form1_Load(object sender, EventArgs e)
        {
            _dtManageApilcation = clsApplicationTypes.GetAllApplicationTypes();
            dgvAplicationTypes.DataSource = _dtManageApilcation;
            label3.Text = dgvAplicationTypes.Rows.Count.ToString();
            if (dgvAplicationTypes.Rows.Count>0)
            {
                dgvAplicationTypes.Columns[0].HeaderText = "ID";
                dgvAplicationTypes.Columns[0].Width = 110;

                dgvAplicationTypes.Columns[1].HeaderText = "Title";
                dgvAplicationTypes.Columns[1].Width = 400;


                dgvAplicationTypes.Columns[2].HeaderText = "Fees";
                dgvAplicationTypes.Columns[2].Width = 100;

            }
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAplicationTypes.CurrentRow.Cells[0].Value;
            frmEditApplicationTypes frmEdit = new frmEditApplicationTypes(id);
            frmEdit.ShowDialog();
            Form1_Load(null,null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
