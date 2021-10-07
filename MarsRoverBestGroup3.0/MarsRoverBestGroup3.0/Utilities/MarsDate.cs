using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarsRoverBestGroup3._0.Models
{

    public static class DateConverter
    {
        /*
        public static double EarthToMarsDate(DateTime dateRequest)
        {
            //create date time object  in 1873 
            DateTime baseTime = new DateTime(1873, 12, 29, 00, 00, 0);

            //find the difference between the two dates
            TimeSpan diff1 = dateRequest.Subtract(baseTime);

            //convert to seconds
            double differenceInSeconds = diff1.TotalSeconds;
     
            //add seconds to formula to get Mars Sol Date
            double MarsSolDate = (differenceInSeconds - 2451549.5 + 12) / 1.02749125 + 44796.0;
            

            DateTime backtodate= MarsSolDate.ConvertTo.DateTime


            return MarsSolDate;

        }

        public static double MarsToEarthDate(DateTime dateRequest)
        {

            //create date time object  in 1873 
            DateTime baseTime = new DateTime(1873, 12, 29, 00, 00, 0);

            //find the difference between the two dates
            TimeSpan diff1 = dateRequest.Subtract(baseTime);

            //convert to seconds
            double differenceInSeconds = diff1.TotalSeconds;

            //add seconds to formula to get Mars Sol Date
            double EarthSolDate = ((differenceInSeconds - 44796) / 1.027425) + 2451537.5;
            return EarthSolDate;

        }
        */
        public static double earthConversionRate = 86400.0 / 88775.0;
        public static double EarthToMarsDate(DateTime earthDate)
        {
            int differenceInDays = (int)earthDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;
            int MarsSolDate = (int)(differenceInDays * earthConversionRate);
            return MarsSolDate;
        }
        public static double marsConversionRate = 88775.0/86400.0;
        public static double MarsToEarthDate(DateTime marsDate)
        {
            int differenceInDays = (int)marsDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;
            int earthSolDate = (int)(differenceInDays * marsConversionRate);
            return earthSolDate;

        }
        //the time the different rovers have been on mars 
        public static double CuriositySol(DateTime roverDate)
        {
            double differenceInDays = (int)roverDate.Subtract(new DateTime(2012, 08, 06)).TotalDays;
            double roverDays = (int)(differenceInDays * earthConversionRate);
            return roverDays;
        }
        public static double PerseveranceSol(DateTime roverDate)
        {
            double differenceInDays = (int)roverDate.Subtract(new DateTime(2021, 02, 18)).TotalDays;
            double roverDays = (int)(differenceInDays * earthConversionRate);
            return roverDays;
        }
        public static double OpportunitySol(DateTime roverDate)
        {
            double differenceInDays = (int)roverDate.Subtract(new DateTime(2003, 07, 07)).TotalDays;
            double roverDays = (int)(differenceInDays * earthConversionRate);
            return roverDays;
        }
        public static double SpiritSol(DateTime roverDate)
        {
            double differenceInDays = (int)roverDate.Subtract(new DateTime(2004, 01, 04)).TotalDays;
            double roverDays = (int)(differenceInDays * earthConversionRate);
            return roverDays;
        }
        public static double SojournerSol(DateTime roverDate)
        {
            double differenceInDays = (int)roverDate.Subtract(new DateTime(1997, 07, 04)).TotalDays;
            double roverDays = (int)(differenceInDays * earthConversionRate);
            return roverDays;
        }
    }
}
