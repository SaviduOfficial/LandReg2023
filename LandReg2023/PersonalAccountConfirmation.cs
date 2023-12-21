using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LandReg2023
{
    public partial class PersonalAccountConfirmation : Form
    {
        PersonalAccountManage pAccManage = new PersonalAccountManage();
        OleDbConnection connection = new OleDbConnection();
        

        //https://www.connectionstrings.com/access-2013/ database accsses string 2013 access
        public PersonalAccountConfirmation()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = G:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb;Persist Security Info=False;";
        }

        private void btnGotoAcc_Click(object sender, EventArgs e)
        {
            //get the user name and pass word from the data base and check the validity
            connection.Open();
            using (OleDbCommand command = new OleDbCommand("SELECT User_ID, Password FROM Login_Details WHERE " +
                "User_ID=@parm1", connection))
            {

                command.Parameters.AddWithValue("@parm1", txtBoxUserId.Text);
                using (OleDbDataReader oleDbDataReader = command.ExecuteReader())
                {
                    // validating the pasword 
                    bool checkPassword = PersonalAccountManage.PWverify(txtBoxPass.Text, Convert.ToString(oleDbDataReader["Password"]));

                    if (checkPassword)
                    {
                        User_Information User_Information = new User_Information();
                        User_Information.Show();
                    }
                    else
                        MessageBox.Show("No match found");
                }

                    
            }
            connection.Close();
            connection.Dispose();


        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtBoxPass.Clear();
            txtBoxUserId.Clear();
        }
    }
}

