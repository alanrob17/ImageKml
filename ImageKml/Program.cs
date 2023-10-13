using ImageKml.Data;
using ImageKml.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ImageKml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var jsonData = KmlData.GetJsonFile(); // single sample KML file for testing.

            var baseDirectory = Environment.CurrentDirectory + @"\json\"; // @"\json\" for dev only @"\" for release 

            var jsonFileList = KmlData.GetJsonFileList(baseDirectory);

            var json = JoinJsonFiles(jsonFileList);

            baseDirectory = Environment.CurrentDirectory;

            string fileName = "alan.json";
            string fullPath = baseDirectory + "\\" + fileName;
            File.WriteAllText(fullPath, json);

            //// Deserialize JSON to the PhotoData objects - change Json to read file instead
            List<PhotoData>? photoData = JsonConvert.DeserializeObject<List<PhotoData>>(json);

            List<Photo> photos = new List<Photo>();

            var startDate = "2023-08-21";
            var endDate = "2023-09-22";

            CreatePhotoList(photoData, photos, startDate, endDate);

            photoData.Clear();

            StringBuilder sb = new();

            sb = KmlData.CreateHeader(sb);

            sb = KmlData.BuildContent(sb, photos);

            sb = KmlData.CreateFooter(sb);

            fileName = "Europe2023Photos.kml";
            fullPath = baseDirectory + "\\" + fileName;
            File.WriteAllText(fullPath, sb.ToString());
        }

        private static void CreatePhotoList(List<PhotoData> photoData, List<Photo> photos, string startdate, string enddate)
        {
            // Get the information from PhotoData that I really need and add it to a list of photos.
            DateTime startDate = DateTime.ParseExact(startdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(enddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            foreach (var fullPhoto in photoData)
            {
                if (fullPhoto.GeoData.Latitude != 0.0 && fullPhoto.GeoData.Longitude != 0.0)
                {
                    Photo photo = new Photo
                    {
                        Name = fullPhoto.Title,
                        Description = fullPhoto.Description,
                        TimeTaken = fullPhoto.PhotoTakenTime.Formatted,
                        CreationTime = DateTimeOffset.FromUnixTimeSeconds(fullPhoto.PhotoTakenTime.Timestamp).UtcDateTime,
                        Latitude = fullPhoto.GeoData.Latitude,
                        Longitude = fullPhoto.GeoData.Longitude,
                        Altitude = (int)fullPhoto.GeoData.Altitude,
                        Url = fullPhoto.Url
                    };

                    if (photo.CreationTime > startDate && photo.CreationTime < endDate)
                    {
                        photos.Add(photo);
                    }
                }
            }
        }

        private static string JoinJsonFiles(IEnumerable<string> jsonFileList)
        {
            var json = string.Empty;
            json = "[\n";

            foreach (var jsonFile in jsonFileList)
            {
                if (File.Exists(jsonFile))
                {
                    string[] lines = File.ReadAllLines(jsonFile);
                    
                    foreach (var line in lines)
                    {
                        json += line + "\n";
                    }
                    json += ",\n";
                }
            }


            json += "]\n";

            json = json.Replace(",\n]", "]");  // remove last comma

            return json;
        }
    }
}