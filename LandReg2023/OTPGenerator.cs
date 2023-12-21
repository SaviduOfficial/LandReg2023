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
    public partial class OTPGenerator : Form
    {
        static List<string> OTP;
        static string OTPCode = "";

        public OTPGenerator()
        {
            InitializeComponent();
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OTPCode = stringOTP(generateOTP()); 
            MessageBox.Show(OTPCode);
        }

        //method to generate OTP and add to a List
        public static List<string> generateOTP()
        {

            for (int i=0; i<4; i++)
            {
                Random myRandom = new Random();
                OTP.Add((myRandom.ToString()));   
            }
            return OTP;    
        }

        //converting list to a String OTPCode
        public static string stringOTP(List<string>mylist)
        {
            string OTP_Code = "";
            foreach(string item in mylist)
            {
                OTP_Code = OTP_Code + item;
            }
            return OTP_Code;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtBoxOTP.Text == OTPCode)
            {
                MessageBox.Show("Verification Succesful");
                //cretaet a class and function to transfer the land id and information to the other person
            }
            else
                MessageBox.Show("Please check the code again");
        }
    }
}
