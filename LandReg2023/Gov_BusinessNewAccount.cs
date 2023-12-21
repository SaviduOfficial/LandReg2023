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
    public partial class Gov_BusinessNewAccount : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        PersonalAccountManage personalAccountManage = new PersonalAccountManage();
        public string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        public Gov_BusinessNewAccount()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";

        }


        private void RadioGovCheckedChanged(object sender, EventArgs e)
        {
            if(RadioGov.Checked == true)
            {
                txtBoxGovDepName.ReadOnly = false;
                txtBoxdepType.ReadOnly = false;
                txtBoxDepNo.ReadOnly = false;
                txtBoxDepAddress.ReadOnly = false;
                txtBoxDepTel.ReadOnly = false;
                txtBoxDepEmail.ReadOnly = false;
                txtBoxDepRecEmail.ReadOnly = false;
                txtboxDepPassword.ReadOnly = false;
            }
            else
            {
                txtBoxGovDepName.ReadOnly = true;
                txtBoxdepType.ReadOnly = true;
                txtBoxDepNo.ReadOnly = true;
                txtBoxDepAddress.ReadOnly = true;
                txtBoxDepTel.ReadOnly = true;
                txtBoxDepEmail.ReadOnly = true;
                txtBoxDepRecEmail.ReadOnly = true;
                txtboxDepPassword.ReadOnly = true;
            }
        }

        private void RadioBusi_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBusi.Checked == true)
            {
                txtBoxbusiName.ReadOnly = false;
                txtBoxBusiType.ReadOnly = false;
                txtBoxBusiRegNo.ReadOnly = false;
                txtBoxBusiAddress.ReadOnly = false;
                txtBoxBusiPass.ReadOnly = false;
                txtBoxBusiNature.ReadOnly = false;
                txtBoxBusiTel.ReadOnly = false;
                txtBoxBusiEmail.ReadOnly = false;
                txtBoxRecBusiEmail.ReadOnly = false;
            }
            else
            {
                txtBoxbusiName.ReadOnly = true;
                txtBoxBusiType.ReadOnly = true;
                txtBoxBusiRegNo.ReadOnly = true;
                txtBoxBusiAddress.ReadOnly = true;
                txtBoxBusiPass.ReadOnly = true;
                txtBoxBusiNature.ReadOnly = true;
                txtBoxBusiTel.ReadOnly = true;
                txtBoxBusiEmail.ReadOnly = true;
                txtBoxRecBusiEmail.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool validate = true;
                if (RadioBusi.Checked == true) // when business radio button checked
                {
                    if (string.IsNullOrEmpty(txtBoxbusiName.Text) || string.IsNullOrEmpty(txtBoxBusiType.Text) || string.IsNullOrEmpty(txtBoxBusiRegNo.Text) ||
                        string.IsNullOrEmpty(txtBoxBusiAddress.Text) || string.IsNullOrEmpty(txtBoxBusiTel.Text) || string.IsNullOrEmpty(txtBoxBusiEmail.Text) ||
                        string.IsNullOrEmpty(txtBoxRecBusiEmail.Text) || string.IsNullOrEmpty(txtBoxBusiPass.Text))
                    {
                        validate = false;
                        MessageBox.Show("please fill the required fields");
                    }
                    else
                    {
                        //Generating user id and save in data in the data base
                        // generating a user ID 
                        string UserId =  PersonalAccountManage.generateUserid(txtBoxBusiRegNo.Text);
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Gov_Dep_Information (Busi_User_ID, Business_Name,Business_Type, Business_Registration_Number," +
                            "Busi_Address, Nature_of_Business , contact_no , Email, Recovery_Email) VALUES(" + UserId + "," + txtBoxbusiName.Text + "," +
                            txtBoxBusiType.Text + ","+  txtBoxBusiRegNo.Text + ","+ txtBoxBusiAddress.Text+ "," + txtBoxBusiNature.Text + ","+txtBoxBusiTel.Text + ","+txtBoxBusiEmail.Text +
                             "," + txtBoxRecBusiEmail.Text+ ");";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Saved! Your UserId is: " + UserId + "please make note before proceed!");
                        connection.Close();
                        connection.Dispose();
                        lbluserid.Text = "UserID: " + UserId;

                        //saving password in the database
                        string password = PersonalAccountManage.Hash_SHA1(txtBoxBusiPass.Text);
                        //saving pasword in the databse
                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command.CommandText = "INSERT INTO Login_Details ([User_ID], [Password]) values ('" + UserId + "','" + password + "')'";
                        command.ExecuteNonQuery();
                        MessageBox.Show("password saved!");
                        connection.Close();
                        connection.Dispose();
                        this.Close();

                    }
                } else if (RadioGov.Checked == true) //when Gov radio button is checked
                {
                    if (string.IsNullOrEmpty(txtBoxGovDepName.Text) || string.IsNullOrEmpty(txtBoxdepType.Text) || string.IsNullOrEmpty(txtBoxDepAddress.Text) ||
                         string.IsNullOrEmpty(txtBoxDepTel.Text) || string.IsNullOrEmpty(txtBoxDepEmail.Text) ||
                        string.IsNullOrEmpty(txtBoxDepRecEmail.Text) || string.IsNullOrEmpty(txtboxDepPassword.Text))
                    {
                        validate = false;
                        MessageBox.Show("please fill the required fields");
                    }
                    else
                    {
                        //Generating user id and save in data in the data base
                 
                        // generating a user ID 
                        string UserId1 =  PersonalAccountManage.generateUserid(txtBoxGovDepName.Text);
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Gov_Dep_Information (Gov_User_ID, Gov_Dep_name, Gov_Deo_Type, Dep_No," +
                            " Dep_Address , Contact_info , Email , Recovery_Email) values (" + UserId1 + "," + txtBoxGovDepName.Text + "," +
                            txtBoxdepType.Text + ","+  txtBoxDepNo.Text + ","+txtBoxDepAddress.Text + ","+txtBoxDepTel.Text + ","+ txtBoxDepEmail.Text +
                             "," + txtBoxDepRecEmail.Text+ ");";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Saved! Your UserId is: " + UserId1 + "please make note before proceed!");
                        connection.Close();
                        connection.Dispose();
                        lbluserid.Text = "UserID: " + UserId1;

                        //Encrypting the password
                        string password1 = PersonalAccountManage.Hash_SHA1(txtboxDepPassword.Text);
                        //saving pasword in the databse
                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command.CommandText = "INSERT INTO Login_Details ([User_ID], [Password]) values ('" + UserId1 + "','" + password1 + "')';";
                        command.ExecuteNonQuery();
                        MessageBox.Show("password saved!");
                        connection.Close();
                        connection.Dispose();
                        this.Close();
                         
                    }
                }
                else
                {
                    MessageBox.Show("Please fill a selected field to proceed further");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (RadioGov.Checked == true)
            {
                txtBoxGovDepName.Clear();
                txtBoxdepType.Clear();
                txtBoxDepNo.Clear();
                txtBoxDepAddress.Clear();
                txtBoxDepTel.Clear();
                txtBoxDepEmail.Clear();
                txtBoxDepRecEmail.Clear();
                txtboxDepPassword.Clear();
            }
            else if (RadioBusi.Checked == true)
            {
                txtBoxbusiName.Clear();
                txtBoxBusiType.Clear();
                txtBoxBusiRegNo.Clear();
                txtBoxBusiAddress.Clear();
                txtBoxBusiPass.Clear();
                txtBoxBusiNature.Clear();
                txtBoxBusiTel.Clear();
                txtBoxBusiEmail.Clear();
                txtBoxRecBusiEmail.Clear();
            }
            else 
            { 
                MessageBox.Show("All Cleared!");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
