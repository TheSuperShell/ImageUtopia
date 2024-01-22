using ImageUtopia.Services;
using Object = ImageUtopia.Models.Object;

const string path = @"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages";

var images = await new ImageServices().LoadImagesAsync(path);

foreach (Object image in images)
{
	Console.WriteLine($"Name: {image.Name}");
	Console.WriteLine($"Path: {image.Path}");
	Console.WriteLine($"Extension: {image.Extension}");
	Console.WriteLine($"Size: {image.Size}");
	Console.WriteLine($"IsImage: {image.IsImage}");
	Console.WriteLine($"Dimensions: {image.Dimensions}");
	Console.WriteLine();
}




