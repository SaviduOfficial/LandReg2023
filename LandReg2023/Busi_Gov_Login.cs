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
    public partial class Busi_Gov_Login : Form
    {
        public Busi_Gov_Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UserIdTxtBox.Text = "";
            PasswordTxtBox.Text = "";
        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            Gov_BusinessNewAccount gov_BusinessNewAccount = new Gov_BusinessNewAccount();
            gov_BusinessNewAccount.ShowDialog();
        }
    }
}
