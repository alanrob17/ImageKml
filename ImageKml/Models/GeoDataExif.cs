using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageKml.Models
{
    internal class GeoDataExif
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Altitude { get; set; }
        public float LatitudeSpan { get; set; }
        public float LongitudeSpan { get; set; }
    }
}
