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
    //Creating a Account for individuals
    public partial class NewPersonalAccount : Form
    {
        string imageLocation = "";
        public OleDbConnection connection = new OleDbConnection();
        PersonalAccountManage pAccManage = new PersonalAccountManage(); // use to encrypt the password characters
        static string user_id = "";
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb"

        //new edited
        public string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb"; // newly added

        public NewPersonalAccount()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";


        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                bool fields_filled = true;
                


                if (string.IsNullOrEmpty(txtBoxFirstName.Text) || string.IsNullOrEmpty(txtBoxLastName.Text) ||
                    string.IsNullOrEmpty(txtBoxBirthDate.Text) || string.IsNullOrEmpty(txtBoxAge.Text) ||
                    string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(txtBoxAddress.Text) ||
                    string.IsNullOrEmpty(txtBoxNicNum.Text) || string.IsNullOrEmpty(txtBoxContactNum.Text) ||
                    string.IsNullOrEmpty(txtBoxPass.Text) || string.IsNullOrEmpty(txtBoxRecContact.Text) ||
                    string.IsNullOrEmpty(txtBoxEmail.Text))

                {
                    MessageBox.Show("Fill the required Fields");
                    fields_filled = false;

                }

                else
                {
                    string gender = "";
                    if (radioButton1.Checked)
                    {
                        gender = "male";
                    }
                    else
                    {
                        gender = "female";
                    }
                    
                   

                    //generating User ID
                    user_id = PersonalAccountManage.generateUserid(txtBoxNicNum.Text);

                    // Saving data in the database
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand())
                    {

                        command.Connection = connection;
                        command.CommandText = command.CommandText = "INSERT INTO Personal_accounts " +
        "(User_ID, First_Name, Middle_Name, Last_Name, Birthdate, Age, Gender, marital_status, Address, email, " +
        "NIC_Number, Digital_photo, Contact_No, Rec_FName, Rec_LName, Recovery_email, Rec_NIC_Num, Recovery_Con_Number) " +
        "VALUES (@User_ID, @First_Name, @Middle_Name, @Last_Name, @Birthdate, @Age, @Gender, @Marital_Status, @Address, @Email, " +
        "@NIC_Number, @Digital_photo, @Contact_No, @Rec_FName, @Rec_LName, @Recovery_email, @Rec_NIC_Num, @Recovery_Con_Number)";
                        

                        command.Parameters.AddWithValue("@User_ID", user_id);
                        command.Parameters.AddWithValue("@First_Name", txtBoxFirstName.Text);
                        command.Parameters.AddWithValue("@Middle_Name", txtBoxMidName.Text);
                        command.Parameters.AddWithValue("@Last_Name", txtBoxLastName.Text);
                        command.Parameters.AddWithValue("@Birthdate", txtBoxBirthDate.Text);
                        command.Parameters.AddWithValue("@Age", txtBoxAge.Text);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Marital_Status", comboBox1.Text);
                        command.Parameters.AddWithValue("@Address", txtBoxAddress.Text);
                        command.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                        command.Parameters.AddWithValue("@NIC_Number", txtBoxNicNum.Text);
                        command.Parameters.AddWithValue("@Digital_photo", imageLocation);
                        command.Parameters.AddWithValue("@Contact_No", txtBoxContactNum.Text);
                        command.Parameters.AddWithValue("@Rec_FName", txtBoxRecFName.Text);
                        command.Parameters.AddWithValue("@Rec_LName", txtBoxRecLName.Text);
                        command.Parameters.AddWithValue("@Recovery_email", txtBoxRecEmail.Text);
                        command.Parameters.AddWithValue("@Rec_NIC_Num", txtBoxRecNICNum.Text);
                        command.Parameters.AddWithValue("@Recovery_Con_Number", txtBoxRecContact.Text);

                        command.ExecuteNonQuery();
                        connection.Close();
                        

                    }
                    //connection.Disposed();


                    MessageBox.Show("Data Saved! \nYour UserId is: " + user_id + "\nplease make note before proceed!");
                    lbluserId.Text =  user_id;
          
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
         

                btnClear.Enabled = false;
                btnBack.Enabled = false;
                btnSave.Enabled = false;
                btnSavePassword.Enabled = true;
                MessageBox.Show("Click Save Password button to continue");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxFirstName.Clear();
            txtBoxMidName.Clear();
            txtBoxLastName.Clear();
            txtBoxBirthDate.Clear();
            txtBoxAge.Clear();
            txtBoxAddress.Clear();
            txtBoxContactNum.Clear();
            txtBoxEmail.Clear();
            txtBoxNicNum.Clear();
            txtBoxPass.Clear();
            txtBoxRecContact.Clear();
            txtBoxRecEmail.Clear();
            txtBoxRecFName.Clear();
            txtBoxRecLName.Clear();
            txtBoxRecNICNum.Clear();
            pictureBox1.BackColor = Color.AliceBlue;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //PersonalAccountConfirmation personalAccountConfirmation = new PersonalAccountConfirmation();
           // personalAccountConfirmation.Show();
        }

      
        private void svePassword_Clicked(object sender, EventArgs e)
        {
                string password = PersonalAccountManage.Hash_SHA1(txtBoxPass.Text);
                //saving pasword in the databse
                try
                {
                    connection.Open();
                    using (OleDbCommand command1 = new OleDbCommand())
                    {
                        command1.Connection = connection;
                        command1.CommandText = "INSERT INTO Login_Details ([User_ID], [Password]) VALUES(@userId, @password)";
                        command1.Parameters.AddWithValue("@userId", lbluserId.Text);
                        command1.Parameters.AddWithValue("@password", password);

                        command1.ExecuteNonQuery();
                        connection.Close();

                    }
                    MessageBox.Show("password saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                    this.Close();


                }
            }

        private void NewPersonalAccount_Load(object sender, EventArgs e)
        {
            btnSavePassword.Enabled = false;
        }
    }
    
    
}
