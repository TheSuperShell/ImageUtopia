using ImageUtopia.Models;

var files = new ImageLoader(@"C:\Users\User\Documents\NET Projects\ImageDBApp\TestImages");
var images = files.GetImages();
foreach (var image in images)
{
	Console.WriteLine(image);
}