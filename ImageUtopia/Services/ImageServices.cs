using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUtopia.Models;

namespace ImageUtopia.Services;

public class ImageServices
{
	public async Task<Object[]> LoadImagesAsync(string path) =>
		await Task.Run(() =>
			Directory.GetFiles(path)
				.Select(filePath => new ObjectBuilder(filePath).Init().Build())
				.Where(result => result.IsOk)
				.Select(result => result.Unwrap())
				.ToArray());
}