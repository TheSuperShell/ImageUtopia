using System.IO;
using System.Threading.Tasks;
using ImageUtopia.Utils;

namespace ImageUtopia.Models;

public record Object(string Name, string Path, string Extension, ulong Size, bool IsImage, (uint, uint) Dimensions)
{
	public Task<Option<Stream>> LoadImage() {
		return Task.FromResult(!IsImage ? Option<Stream>.None() : File.OpenRead(Path));
	}
};