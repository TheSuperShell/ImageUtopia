using System.IO;

namespace ImageUtopia.Models;

public class ImageLoader(string path)
{
	private string _path = path;
	
	public string[] GetImages()
	{
		return Directory.GetFiles(_path);
	}
}