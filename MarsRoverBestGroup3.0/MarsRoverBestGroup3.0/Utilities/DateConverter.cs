using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarsRoverBestGroup3._0.Models
{

    public static class DateConverter
    {
        public static double earthConversionRate = 86400.0 / 88775.0;
        public static int EarthToMarsDate(DateTime earthDate)
        {

           
           if (earthDate >= new DateTime(1873, 12, 29)){
                double differenceInDays = earthDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;

                double MarsSolDate = (differenceInDays * earthConversionRate);

                return (int)Math.Floor(MarsSolDate);

            }
            else
            {
                throw new ArgumentException("Make sure date is after 29/12/1873");
            }
                

           
        }
        public static DateTime MarsToEarthDate(string marsDate)
        {

            bool isNumeric = double.TryParse(marsDate, out double number);
            if (isNumeric)
            {
                double secondsSinceSolOrigin = number * 88775.0;
                DateTime earthDateTime = new DateTime(1873, 12, 29, 12, 0, 0).AddSeconds(secondsSinceSolOrigin);
                var earthDate = earthDateTime.Date;
                return earthDate;

            }
            else
            {
                throw new Exception("Mars Sol date has to be a number"); 
            }
            

        }

        public static int CurrentMarsDate()
        {
            return  EarthToMarsDate(DateTime.Now.Date);
            
        }
        //the time the different rovers have been on mars 


        private static DateTime CuriosityLandingDate = new DateTime(2012, 08, 06);

        public static int CuriositySol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(CuriosityLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Ceiling(roverDays);
        }
        private static DateTime PerserveranceLandingDate = new DateTime(2021, 02, 18);
        public static int PerseveranceSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(PerserveranceLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Floor(roverDays);
        }
        private static DateTime OpportunityLandingDate = new DateTime(2004, 01, 25);
        public static int OpportunitySol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(OpportunityLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Ceiling(roverDays);
        }
        private static DateTime SpiritLandingDate = new DateTime(2004, 01, 04);
        public static int SpiritSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(SpiritLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Floor(roverDays);
        }
        private static DateTime SojournerLandingDate = new DateTime(1997, 07, 04);
        public static int SojournerSol(DateTime roverDate)
        {
            double differenceInDays = roverDate.Subtract(SojournerLandingDate).TotalDays;
            var roverDays = (differenceInDays * earthConversionRate);
            return (int)Math.Ceiling(roverDays);
        }
    }
}
