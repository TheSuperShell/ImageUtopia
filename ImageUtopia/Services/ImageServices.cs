using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUtopia.Models;
using ImageUtopia.Utils;
using Object = ImageUtopia.Models.Object;

namespace ImageUtopia.Services;

public class ImageServices
{
	public async Task<List<Result<Object, Exception>>> LoadImagesAsync(string path) =>
		await Task.Run(() =>
			Directory.GetFiles(path)
				.Select(filePath => new ObjectBuilder(filePath).Init().Build())
				.ToList());
}