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

         
        public static int earthConversionRate = 86400/ 88775;
        public static int EarthToMarsDate(DateTime earthDate)
        {
            int differenceInDays = (int)earthDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;
            int MarsSolDate = (int)(differenceInDays * earthConversionRate);
            return MarsSolDate;
        }
        public static int marsConversionRate = 88775/86400;
        public static int MarsToEarthDate(DateTime marsDate)
        {
            int differenceInDays = (int)marsDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;
            int earthSolDate = (int)(differenceInDays * marsConversionRate);
            return earthSolDate;

        }
        //the time the different rovers have been on mars 


       private static DateTime CuriosityLandingDate = new DateTime(2012, 08, 06);

        public static int CuriositySol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(CuriosityLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Round(roverDays);
        }
        private static DateTime PerserveranceLandingDate = new DateTime(2021, 02, 18);
        public static int PerseveranceSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(PerserveranceLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Round(roverDays);
        }
        private static DateTime OppurtunityLandingDate = new DateTime(2003, 07, 07);
        public static int OpportunitySol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(OppurtunityLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Round(roverDays);
        }
        private static DateTime SpiritLandingDate = new DateTime(2004, 01, 04);
        public static int SpiritSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(SpiritLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Round(roverDays);
        }
        private static DateTime SojournerLandingDate = new DateTime(1997, 07, 04);
        public static int SojournerSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(SojournerLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Round(roverDays);
        }
    }
}
