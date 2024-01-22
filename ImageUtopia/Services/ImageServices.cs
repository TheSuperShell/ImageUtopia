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
				.Select(filePath => new MetadataExtractor(filePath))
				.Where(extractor => extractor.IsValidFile)
				.Select(extractor => new Object(
					extractor.Name, 
					extractor.Path,
					extractor.Extension,
					extractor.Size,
					extractor.IsImage,
					extractor.Dimensions)
				).ToArray());
}