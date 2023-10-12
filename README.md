# Image KML project

This program is used to collect the Google JSON documents that are attached to each of the JPG files in Google Photo.

I intend to join all of the JSON files together into one JSON file that collects all of the photo data for a particular time period. At the moment I am only interested in the data from our 2023 Europe trip.

## Work in progress

This is a list of tasks that I need to complete to finish the project.

Collect all JSON files into one folder so that I can consume them.

I need to filter the JSON files as there are a number of files I don't want to bring in to my list. These include files with the words (case insensitive):

* edited
* mapsme
* screenshot
* effects
* photos
* animation
* pano
* ([0-9])

Filter by a start and end date (so I can select photos from Europe)

Join filtered JSON files into 1 large JSON file.

Serialise all locations into a List.

Filter this List into a new Photo List that only contains the data I need to build a KML file.

Generate a KML file from the Photo List.

## To-Do

This program uses the metadata from Google. I need to rewrite this program to grab the EXIF metadata from the images themselves.
