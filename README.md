# Image KML project

This program is used to collect the Google JSON documents that are attached to each of the JPG files in Google Photo.

This is a sample of the JSON data that Google collects for a photo.

```json
{
  "title": "20230823_101236.jpg",
  "description": "",
  "imageViews": "3",
  "creationTime": {
    "timestamp": "1692812685",
    "formatted": "23 Aug 2023, 17:44:45 UTC"
  },
  "photoTakenTime": {
    "timestamp": "1692781956",
    "formatted": "23 Aug 2023, 09:12:36 UTC"
  },
  "geoData": {
    "latitude": 55.8621286,
    "longitude": -4.252332,
    "altitude": 70.0,
    "latitudeSpan": 0.0,
    "longitudeSpan": 0.0
  },
  "geoDataExif": {
    "latitude": 55.8621286,
    "longitude": -4.252332,
    "altitude": 70.0,
    "latitudeSpan": 0.0,
    "longitudeSpan": 0.0
  },
  "url": "Link to Google Photo",
  "googlePhotosOrigin": {
    "mobileUpload": {
      "deviceFolder": {
        "localFolderName": ""
      },
      "deviceType": "ANDROID_PHONE"
    }
  }
}
```

I create a single JSON file that contains all of the photo metadata.

From here I grab the data that I need and filter it to the start and end dates that I want to capture.

I then reformat the data into a KML file that I can open in Google maps.

## To-Do

This program uses the metadata from Google. I need to rewrite this program to grab the EXIF metadata from the images themselves.
