using ImageUtopia.Services;

const string path = @"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages";

var images = await new ImageServices().LoadImagesAsync(path);

foreach (var image in images) {
	Console.WriteLine(image.Name);
	Console.WriteLine(image.Path);
	Console.WriteLine(image.Dimensions);
	Console.WriteLine(image.IsImage);
	Console.WriteLine(image.Extension);
	Console.WriteLine(image.Size);
	Console.WriteLine("___________________");
}

await Task.Delay(25000);




