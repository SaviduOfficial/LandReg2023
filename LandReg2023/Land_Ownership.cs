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
    public partial class Land_Ownership : Form
    {
        public OleDbConnection connection = new OleDbConnection();
        public string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        string land_id = "";

        public Land_Ownership(string lid)
        {
            InitializeComponent();
            land_id = lid;
            txtboxlid.Text = land_id;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ICT_PROJECT\C# Land Reg\LandReg2023\LandReg2023db.accdb";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtboxlid.Clear();
            txtboxoid.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtboxlid.Text != "" && txtboxoid.Text != "" )
            {
                
                //save in the database
            }
            else
            {
                MessageBox.Show("please fill the required fields! ");
            }
        }
    }
}
