using ImageKml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageKml.Data
{
    internal class KmlData
    {
        internal static StringBuilder BuildContent(StringBuilder sb, List<Photo> photos)
        {
            foreach (var photo in photos)
            {
                sb.Append("\t<Placemark>\n");
                var name = photo.Name.Replace(".jpg", string.Empty);
                sb.Append($"\t\t<name>{name}</name>\n");

                var description = string.Empty;
    
                description = $"<![CDATA[{photo.TimeTaken}\n{photo.Url}\n{photo.Name}\n{photo.Altitude}]]>";
                sb.Append($"\t\t<description>{description}</description>\n");
                sb.Append($"\t\t<TimeStamp><when>{photo.CreationTime.Value}</when></TimeStamp>\n"); // 2023-09-19T11:21:21.113Z
                sb.Append("\t\t<styleUrl>#placemark-red</styleUrl>\n");
                sb.Append($"\t\t<Point><coordinates>{photo.Longitude},{photo.Latitude}</coordinates></Point>\n"); // -0.12692465,51.51472
                sb.Append("\t</Placemark>\n");
            }

            return sb;
        }

        internal static StringBuilder CreateHeader(StringBuilder sb)
        {
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
            sb.Append("<kml xmlns=\"http://earth.google.com/kml/2.2\">\n");
            sb.Append("<Document>\n");

            sb.Append("\t<Style id=\"placemark-red\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>https://maps.gstatic.com/mapfiles/ridefinder-images/mm_20_red.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-blue\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-blue.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-purple\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-purple.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-yellow\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-yellow.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-pink\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-pink.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-brown\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-brown.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-green\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-green.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-orange\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-orange.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-deeppurple\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-deeppurple.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-lightblue\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-lightblue.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-cyan\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-cyan.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-teal\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-teal.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-lime\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-lime.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-deeporange\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-deeporange.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-gray\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-gray.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<Style id=\"placemark-bluegray\">\n");
            sb.Append("\t\t<IconStyle>\n");
            sb.Append("\t\t\t<Icon>\n");
            sb.Append("\t\t\t\t<href>http://maps.me/placemarks/placemark-bluegray.png</href>\n");
            sb.Append("\t\t\t</Icon>\n");
            sb.Append("\t\t</IconStyle>\n");
            sb.Append("\t</Style>\n");
            sb.Append("\t<name>Europe 2023 - Photo Location Points</name>\n");
            sb.Append("\t<description>Our Europe 2023 trip.</description>\n");
            sb.Append("\t<visibility>1</visibility>\n");

            return sb;
        }

        internal static StringBuilder CreateFooter(StringBuilder sb)
        {
            sb.Append("\t</Document>\n");
            sb.Append("</kml>\n");

            return sb;
        }

        internal static IEnumerable<string> GetJsonFileList(string folder)
        {
            var dir = new DirectoryInfo(folder);

            var jsonFileList = new List<string>();

            GetJsonFiles(dir, jsonFileList);

            return jsonFileList;
        }

        private static void GetJsonFiles(DirectoryInfo d, ICollection<string> jsonFileList)
        {
            var files = d.GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                var fileName = file.FullName;

                var dirName = d.FullName;

                if (Path.GetExtension(fileName.ToLowerInvariant()) == ".json")
                {
                    bool badName = CheckFileName(fileName);

                    if (!badName)
                    {
                        jsonFileList.Add(fileName);
                    }
                }
            }
        }

        private static bool CheckFileName(string fileName)
        {
            string pattern = @"(?:edited|mapsme|screenshot|effects|photos|animation|pano|~|\(|\)|\w+_\w+_\w+)";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = regex.Matches(fileName);

            var fail = false;

            foreach (Match match in matches)
            {
                if (match.Success == true)
                {
                    fail = true;
                    break;
                }
            }

            return fail;
        }

        internal static string GetJsonFile()
        {
            var jsonString = string.Empty;

            // Your JSON data as a string
            jsonString = @"{
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


            return jsonString;
        }
    }
}
