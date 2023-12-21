using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LandReg2023
{
    class getGPSLocations
    {
        //Land ID generate..
        static double id = 0;

        public static string generateLandId(List<string>gpsList )
        {
            foreach (string item in gpsList){
                id = id + (Convert.ToDouble(item));
            }id = id / (5);
            DateTime dateTime = new DateTime();

            //Generating Id for the Land
            string Lid = Convert.ToString(id) + dateTime;  
            string LandId = String.Concat(Lid.Where(c => !Char.IsWhiteSpace(c)));

            return LandId;
        }




    }
}
