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
    public partial class InsertLandDetails : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        public string connectionString =  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        public string landid="";


        public InsertLandDetails(string Lid)
        {
            InitializeComponent();
            landid = Lid;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(); // if this not work type using oledbCommand
                command.Connection = connection;
                command.CommandText = "INSERT INTO Land_info (Name_of_area,City,District,Province,Area_of_land,Type_of_Land,Constructions_in_Land,North_to_land,South_to_land,East_to_Land,West_to_Land," +
                    "Other_information) VALUES(@arealocation, @city, @district, @province, @landarea, @landtype, @consinland, @north, @south, @east, @west, @otherinfo)"; // ,User_ID,Busi_User_ID,Gov_User_ID values @userid,@busiuser,@govuser
                command.Parameters.AddWithValue("@arealocation", txtBoxareaname.Text);
                command.Parameters.AddWithValue("@city", txtBoxcity.Text);
                command.Parameters.AddWithValue("@district", txtBoxDistrict.Text);
                command.Parameters.AddWithValue("@province", txtBoxProvince.Text);
                command.Parameters.AddWithValue("@landarea", txtBoxLandArea.Text);
                command.Parameters.AddWithValue("@landtype", txtBoxLandtype.Text);
                command.Parameters.AddWithValue("@consinland", txtBoxConsInLand.Text);
                command.Parameters.AddWithValue("@north", txtBoxNorth.Text);
                command.Parameters.AddWithValue("@south", txtBoxSouth.Text);
                command.Parameters.AddWithValue("@east", TxtBoxEast.Text);
                command.Parameters.AddWithValue("@west", txtBoxWest.Text);
                command.Parameters.AddWithValue("@otherinfo", txtBoxinfo.Text);
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("data saved!");
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            Land_Ownership land_Ownership = new Land_Ownership(landid);
            land_Ownership.ShowDialog();
            this.Close();
            //Land_Registration land_Registration = new Land_Registration();
            //land_Registration.ShowDialog();
        }

        private void InsertLandDetails_Load(object sender, EventArgs e)
        {
            txtBoxinfo.Text = landid;
            txtBoxinfo.Text = Environment.NewLine; // Land Id comes from land registration to land details txtbox
        }
    }
}
