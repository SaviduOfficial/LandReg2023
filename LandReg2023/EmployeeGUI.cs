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
    public partial class EmployeeGUI : Form
    {
        OleDbConnection Connection = new OleDbConnection();
        public String ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        static string empid = "";
        public static string extractor(string my_value)
        {
            empid = my_value;// change my value varibale name
            return empid;
        }
        
        public EmployeeGUI(String value)
        {
            Employee_login employee_Login = new Employee_login();
            InitializeComponent();
            string empId = value;
            extractor(empId);
            Connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        }

        private void EmployeeGUI_Load(object sender, EventArgs e)
        {
            labelEmpID.Text = empid;
            Connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = Connection;
            command.CommandText = "SELECT First_Name, Last_Name, Address, Email, Contact_Number, NIC_Number FROM Employees WHERE Emp_ID=@Emp";
            command.Parameters.AddWithValue("@Emp", empid);
            using (OleDbDataReader oleDbDataReader = command.ExecuteReader())
            {
                if (oleDbDataReader.HasRows == true)
                {
                    MessageBox.Show("found the match!");

                }
                else
                {
                   
                }
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Land_Registration land_Registration = new Land_Registration();
            land_Registration.Show();
        }
    }
}
