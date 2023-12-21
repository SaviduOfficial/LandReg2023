using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LandReg2023
{
    class PersonalAccountManage
    {

        // Encripting the User password to Enter in the Database 
        public static string Hash_SHA1(string inputtxt)
        {
            using(SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(inputtxt));
                var sb = new StringBuilder(hash.Length * 2);

                foreach(byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        //generating User Id
        public static string generateUserid(string idnum)
        {
            DateTime dateTime = DateTime.Now;
            string temp = idnum + dateTime;
            string user_id = String.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));

            return user_id;
        }

        // Decrypting password
        public static bool PWverify(string text1, string text2)
        {
            if (text2 == Hash_SHA1(text1))
            {
                return true;
            }
                
            else
                return false;
            

            
        }
    }
}
