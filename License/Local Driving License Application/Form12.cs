using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License_Application
{
    public partial class Form12: Form
    {
        public Form12(int ID)
        {
            InitializeComponent();
            ucLocalDrivingApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(ID);
        }
    }
}
