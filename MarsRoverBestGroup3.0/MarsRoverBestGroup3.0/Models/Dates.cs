using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverBestGroup3._0.Models
{
    public class Dates
    {
        public DateTime earthInputDate { get; set; }

        public double marsInputDate { get; set; }


    }

    public class HomepageViewModel
    {
        public double marsOutputDate { get; set; }
        public DateTime earthOutputDate { get; set; }
    }
}