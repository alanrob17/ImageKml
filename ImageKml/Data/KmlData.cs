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
