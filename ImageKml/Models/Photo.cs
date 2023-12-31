﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageKml.Models
{
    // This is the final data I wanted to extract.
    internal class Photo
    {
        public string? Name { get; set; }  // Title
        public string? Description { get; set; }
        public string? TimeTaken { get; set; } // Formatted
        public DateTime? CreationTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public string? Url { get; set; }
    }
}
