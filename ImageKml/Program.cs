using ImageKml.Models;
using Newtonsoft.Json;

namespace ImageKml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Your JSON data as a string
            string jsonData = @"{
            ""title"": ""20230831_153646.jpg"",
            ""description"": """",
            ""imageViews"": ""3"",
            ""creationTime"": {
                ""timestamp"": ""1693498503"",
                ""formatted"": ""31 Aug 2023, 16:15:03 UTC""
            },
            ""photoTakenTime"": {
                ""timestamp"": ""1693492606"",
                ""formatted"": ""31 Aug 2023, 14:36:46 UTC""
            },
            ""geoData"": {
                ""latitude"": 58.2164034,
                ""longitude"": -4.9984234999999995,
                ""altitude"": 279,
                ""latitudeSpan"": 0,
                ""longitudeSpan"": 0
            },
            ""geoDataExif"": {
                ""latitude"": 58.2164034,
                ""longitude"": -4.9984234999999995,
                ""altitude"": 279,
                ""latitudeSpan"": 0,
                ""longitudeSpan"": 0
            },
            ""url"": ""https://photos.google.com/photo/AF1QipOmQt_VALZybqR9tCMFmUUDc7fcUcmLY0EJNQ2q"",
            ""googlePhotosOrigin"": {
                ""mobileUpload"": {
                    ""deviceFolder"": {
                        ""localFolderName"": """"
                    },
                    ""deviceType"": ""ANDROID_PHONE""
                }
            }
        }";

            // Deserialize JSON to the PhotoData object
            PhotoData photoData = JsonConvert.DeserializeObject<PhotoData>(jsonData);

            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(photoData.PhotoTakenTime.Timestamp).UtcDateTime;

            // Access properties
            Console.WriteLine("Title: " + photoData.Title);
            Console.WriteLine("Description: " + photoData.Description);
            Console.WriteLine("Time Taken: " + photoData.PhotoTakenTime.Formatted);
            Console.WriteLine("Creation Time: " + dateTime);
            Console.WriteLine("Latitude: " + photoData.GeoData.Latitude);
            Console.WriteLine("Longitude: " + photoData.GeoData.Longitude);
            Console.WriteLine("Altitude: " + photoData.GeoData.Altitude);
            Console.WriteLine("URL: " + photoData.Url);


            ImageData image = new ImageData
            {
                Name = photoData.Title,
                Description = photoData.Description,
                TimeTaken = photoData.PhotoTakenTime.Formatted,
                CreationTime = dateTime,
                Latitude = photoData.GeoData.Latitude,
                Longitude = photoData.GeoData.Longitude,
                Altitude = photoData.GeoData.Altitude,
                Url = photoData.Url
            };
        }
    }
}