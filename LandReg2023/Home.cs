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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Personal_Login personal_Login = new Personal_Login();
            personal_Login.Show();

            //Land_Registration land_Registration = new Land_Registration();
            //land_Registration.Show();
        }

        private void btnGovBusi_Click(object sender, EventArgs e)
        {
            Busi_Gov_Login busi_Gov_Login = new Busi_Gov_Login();
            busi_Gov_Login.Show();
        }

        private void BtnLandReg_Click(object sender, EventArgs e)
        {
            Employee_login employee_Login = new Employee_login();
            employee_Login.Show();
        }
    }
}
