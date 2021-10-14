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

        public string DateErrorMessage { get;  set; }
        public string ParameterErrorMessage { get; set; }

        public APOD apod { get; set; }
    }

    public class RoverSols
    {
        public DateTime roverSolInput { get; set; }
        public int CuriositySolOutput { get; set; }
        public int OpportunitySolOutput { get; set; }
        public int SpiritSolOutput { get; set; }
        public int SojournerSolOutput { get; set; }
        public int PerserveranceSolOutput { get; set; }
    }
}