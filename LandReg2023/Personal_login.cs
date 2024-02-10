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

    public partial class Personal_Login : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        PersonalAccountManage pAccManage = new PersonalAccountManage(); // use to encrypt the password characters
        public string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        public Personal_Login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
    }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxUserId.Text = "";
            txtBoxPass.Text = "";
        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            NewPersonalAccount newPersonalAccount = new NewPersonalAccount();
            newPersonalAccount.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string phash = PersonalAccountManage.Hash_SHA1(txtBoxPass.Text);
                //get the user name and pass word from the data base and check the validity
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT* FROM Login_Details WHERE User_ID=@user and Password=@pass", connection)) 
                    
                {
                    
                    command.Parameters.AddWithValue("@user", txtBoxUserId.Text);
                    command.Parameters.AddWithValue("@pass", phash);
                    using (OleDbDataReader oleDbDataReader = command.ExecuteReader())
                    {
                        // validating the pasword 
                       // bool checkPassword = PersonalAccountManage.PWverify(txtBoxPass.Text, Convert.ToString(oleDbDataReader["Password"]));

                        if (oleDbDataReader.HasRows == true)
                        {
                            connection.Close();
                            User_Information User_Information = new User_Information(txtBoxUserId.Text);
                            User_Information.Show();

                            this.Close();
                            // get user information from the database and show it in the user_information
                        }
                        else
                        {
                            connection.Close();
                            MessageBox.Show("No match found");
                        }
                            
                    }

                }
                connection.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
