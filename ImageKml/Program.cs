using ImageKml.Data;
using ImageKml.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ImageKml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var jsonData = KmlData.GetJsonFile(); // single sample KML file.

            var baseDirectory = Environment.CurrentDirectory + @"\json\"; // @"\json\" for dev only @"\" for release 

            var jsonFileList = KmlData.GetJsonFileList(baseDirectory);

            string json = JoinJsonFiles(jsonFileList);


            //// Deserialize JSON to the PhotoData object
            //PhotoData photoData = JsonConvert.DeserializeObject<PhotoData>(jsonData);

            //DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(photoData.PhotoTakenTime.Timestamp).UtcDateTime;

            //// Access properties
            //Console.WriteLine("Title: " + photoData.Title);
            //Console.WriteLine("Description: " + photoData.Description);
            //Console.WriteLine("Time Taken: " + photoData.PhotoTakenTime.Formatted);
            //Console.WriteLine("Creation Time: " + dateTime);
            //Console.WriteLine("Latitude: " + photoData.GeoData.Latitude);
            //Console.WriteLine("Longitude: " + photoData.GeoData.Longitude);
            //Console.WriteLine("Altitude: " + photoData.GeoData.Altitude);
            //Console.WriteLine("URL: " + photoData.Url);


            //ImageData image = new ImageData
            //{
            //    Name = photoData.Title,
            //    Description = photoData.Description,
            //    TimeTaken = photoData.PhotoTakenTime.Formatted,
            //    CreationTime = dateTime,
            //    Latitude = photoData.GeoData.Latitude,
            //    Longitude = photoData.GeoData.Longitude,
            //    Altitude = photoData.GeoData.Altitude,
            //    Url = photoData.Url
            //};
        }

        private static string JoinJsonFiles(IEnumerable<string> jsonFileList)
        {
            var json = string.Empty;

            foreach (var jsonFile in jsonFileList)
            {
                if (File.Exists(jsonFile))
                {
                    string[] lines = File.ReadAllLines(jsonFile);

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    
                }
            }

            return json;
        }
    }
}