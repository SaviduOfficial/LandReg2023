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
    public partial class User_Information : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        public string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        public User_Information(string userId)
        {
            InitializeComponent();
            labelUserId.Text = userId;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

    }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Land_Registration land_Registration = new Land_Registration();
            land_Registration.Show();
            
        }

        private void User_Information_Load(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT* FROM Personal_accounts WHERE User_ID=@user";

            // User_ID, First_Name, Middle_Name, Last_Name, Birthdate, Age, Gender, marital_status, Address, email, " +
           // "NIC_Number, Digital_photo, Contact_No, Rec_FName, Rec_LName, Recovery_email, Rec_NIC_Num, Recovery_Con_Number "
               // + "FROM Personal_accounts

            command.Parameters.AddWithValue("@user", labelUserId.Text); // need to chnge the sql statement
            using (OleDbDataReader oleDbDataReader = command.ExecuteReader())
            {
                while (oleDbDataReader.Read())
                {
                    DescriptiontxtBox.Text += "User ID: " + oleDbDataReader[0];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "First Name: "+ oleDbDataReader[1];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Middle Name: " + oleDbDataReader[2];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Last Name: " + oleDbDataReader[3];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Birthdate: " + oleDbDataReader[4];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Age: " + oleDbDataReader[5];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Gender: " + oleDbDataReader[6];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Marital status: " + oleDbDataReader[7];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Address: " + oleDbDataReader[8];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Email: " + oleDbDataReader[9];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "NIC Number: " + oleDbDataReader[10];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Digital Photo: " + oleDbDataReader[11]; //photo of the user into the pic box
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Contact Number: " + oleDbDataReader[12];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Information of the recovery person: ";
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Rec First Name: " + oleDbDataReader[13];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Rec Last Name: " + oleDbDataReader[14];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Recovery Email: " + oleDbDataReader[15];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Recovery NIC: " + oleDbDataReader[16];
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Text += "Recovery Contact Number: " + oleDbDataReader[17];
                    //...
                    DescriptiontxtBox.Text += Environment.NewLine;
                    DescriptiontxtBox.Enabled = false;
                }
            }


            /* {
                 if (oleDbDataReader.HasRows == true)
                 {
                     MessageBox.Show("found the match!");

                 }
                 else
                 {

                }
             }*/
        }
    }
}
