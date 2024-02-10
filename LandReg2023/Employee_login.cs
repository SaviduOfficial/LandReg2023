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
    public partial class Employee_login : Form
    {
        PersonalAccountManage pa = new PersonalAccountManage();
        public OleDbConnection connection = new OleDbConnection();
        public string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

       
        public Employee_login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UserIdTxtBox.Text = "";
            PasswordTxtBox.Text = "";
        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            EmployeeNewAccount employeeNewAccount = new EmployeeNewAccount();
            employeeNewAccount.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // turning password into SHA1
                
                string phash = PersonalAccountManage.Hash_SHA1(PasswordTxtBox.Text);

                connection.Open();
                //OleDbCommand command = new OleDbCommand();
                using (OleDbCommand command = new OleDbCommand("SELECT* FROM Employee_login WHERE Emp_ID=@emp and Password=@pass", connection))
                {
                    //command.CommandText = "SELECT* FROM Employee_login WHERE Emp_ID=@emp and Password=@pass";
                    command.Parameters.AddWithValue("@emp", UserIdTxtBox.Text);
                    command.Parameters.AddWithValue("@pass", phash);
                    using (OleDbDataReader oleDbDataReader = command.ExecuteReader())
                    {
                        // validating the pasword 
                        // bool checkPassword = PersonalAccountManage.PWverify(txtBoxPass.Text, Convert.ToString(oleDbDataReader["Password"]));

                        if (oleDbDataReader.HasRows == true)
                        {
                            connection.Close();
                            EmployeeGUI employee = new EmployeeGUI(UserIdTxtBox.Text);// bringing userid to employee GUI need to validated the IDs before
                            employee.Show();


                        }
                        else
                        {
                            connection.Close();
                            MessageBox.Show("No match found");
                        }

                    }
                }
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
