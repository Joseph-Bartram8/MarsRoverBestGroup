using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarsRoverBestGroup3._0.Models
{

    public class MarsDate
    {
        public double EarthToMarsDate(DateTime dateQuery)
        {
            
            DateTime baseTime = new DateTime(1873, 12, 29, 00, 00, 0);
            DateTime datequery = new DateTime(2021, 10, 04, 00, 00, 0);

            System.TimeSpan diff1 = datequery.Subtract(baseTime);

            Console.WriteLine(  diff1);
            //create date time object  in 18?? 

            //input date subract date of 18?? 
            //Convert that to seconds
            //feed seconds into formula
            //put in a method and return the result
            //DateTime theDate = DateTime.UtcNow;

        //double MarsSolDate = (theDate - 2451561.5 ) / 1.02749125 + 44796.0;




        }
        
        

    }
}
