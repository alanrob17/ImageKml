using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageKml.Models
{
    internal class GeoData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public int LatitudeSpan { get; set; }
        public int LongitudeSpan { get; set; }
    }
}
