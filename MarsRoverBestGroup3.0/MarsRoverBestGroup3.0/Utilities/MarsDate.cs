using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarsRoverBestGroup3._0.Models
{

    public class MarsDate
    {
        public double EarthToMarsDate(DateTime dateRequest)
        {
            //create date time object  in 1873 
            DateTime baseTime = new DateTime(1873, 12, 29, 00, 00, 0);

            //find the difference between the two dates
            TimeSpan diff1 = dateRequest.Subtract(baseTime);

            //convert to seconds
            double differenceInSeconds = diff1.TotalSeconds;
     
            //add seconds to formula to get Mars Sol Date
            double MarsSolDate = (differenceInSeconds - 2451561.5 ) / 1.02749125 + 44796.0;

            return MarsSolDate;

        }
     
    }
}
