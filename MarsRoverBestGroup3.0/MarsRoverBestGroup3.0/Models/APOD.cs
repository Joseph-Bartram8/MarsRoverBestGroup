using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverBestGroup3._0.Models
{
    public class APOD
    {
        public string date;
        public string explanation;
        public string hdurl;
        public string title;
        public string url;

        public APOD(string date, string explanation, string hdurl, string title, string url)
        {
            this.date = date;
            this.explanation = explanation;
            this.hdurl = hdurl;
            this.title = title;
            this.url = url; 
        }
    }
}
