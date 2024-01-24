using ImageUtopia.Services;

const string path = @"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages";

var images = await new ImageServices().LoadImagesAsync(path);

images.ForEach(result => result.Match(res => {
	Console.WriteLine(res.Name);
	Console.WriteLine(res.Path);
	Console.WriteLine(res.Dimensions);
	Console.WriteLine(res.IsImage);
	Console.WriteLine(res.Extension);
	Console.WriteLine(res.Size);
	Console.WriteLine("___________________");
	return 0;
}, exception => {
	Console.WriteLine(exception); 
	return 0;
}));




