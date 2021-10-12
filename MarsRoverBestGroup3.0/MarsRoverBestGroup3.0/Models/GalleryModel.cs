using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverBestGroup3._0.Models
{
    public class GalleryModel
    {
        public List<Photo> photos { get; set; }
        public DateTime date { get; set; }
        public string rover { get; set; }
        public string camera { get; set; }
    }
}
