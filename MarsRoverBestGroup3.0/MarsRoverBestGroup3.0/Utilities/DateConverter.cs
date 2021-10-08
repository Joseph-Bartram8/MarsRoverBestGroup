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
            int differenceInDays = (int)earthDate.Subtract(new DateTime(1873, 12, 29)).TotalDays;
            int MarsSolDate = (int)(differenceInDays * earthConversionRate);
            return MarsSolDate;
        }

        public static DateTime MarsToEarthDate(double marsDate)
        {
            double secondsSinceSolOrigin = marsDate * 88775.0;
            DateTime earthDateTime = new DateTime(1873, 12, 29, 12, 0, 0).AddSeconds(secondsSinceSolOrigin);
            var earthDate = earthDateTime.Date;
            return earthDate;
        }

    }
}