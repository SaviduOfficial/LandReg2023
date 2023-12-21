using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandReg2023
{
    public partial class User_Information : Form
    {
        public User_Information()
        {
            InitializeComponent();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Land_Registration land_Registration = new Land_Registration();
            land_Registration.Show();
        }
    }
}
