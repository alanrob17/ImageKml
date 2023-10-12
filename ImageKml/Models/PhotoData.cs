using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageKml.Models
{
    internal class PhotoData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageViews { get; set; }
        public CreationTime CreationTime { get; set; }
        public PhotoTakenTime PhotoTakenTime { get; set; }
        public GeoData GeoData { get; set; }
        public GeoDataExif GeoDataExif { get; set; }
        public string Url { get; set; }
        public GooglePhotosOrigin GooglePhotosOrigin { get; set; }

    }
}
