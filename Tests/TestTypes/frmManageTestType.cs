using DVLD.Business;
using DVLD.People;
using DVLD.Tests.TestTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmManageTestType: Form
    {
        private static DataTable _dtTestType;
        public frmManageTestType()
        {
            InitializeComponent();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _dtTestType = clsManageTestType.GetAllTestTypes();
            dgvManageTest.DataSource = _dtTestType;
            lblRecords.Text = dgvManageTest.Rows.Count.ToString();
            if (dgvManageTest.Rows.Count > 0)
            {
                dgvManageTest.Columns[0].HeaderText = "ID";
                dgvManageTest.Columns[0].Width = 120;

                dgvManageTest.Columns[1].HeaderText = "Title";
                dgvManageTest.Columns[1].Width = 120;

                dgvManageTest.Columns[2].HeaderText = "Description";
                dgvManageTest.Columns[2].Width = 400;

                dgvManageTest.Columns[3].HeaderText = "Fees";
                dgvManageTest.Columns[3].Width = 120;
            }
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes editTestTypes = new frmEditTestTypes((clsManageTestType.enTestType)dgvManageTest.CurrentRow.Cells[0].Value);
            editTestTypes.ShowDialog();
            frmManageTestType_Load(null, null);
        }
    }
}
