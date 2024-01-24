using System;
using System.Drawing;
using System.IO;
using ImageUtopia.Utils;

namespace ImageUtopia.Models;

public class ObjectBuilder(string path)
{
	private string? _name;
	private string? _extension;
	private ulong _size;
	private bool _isImage;
	private (uint, uint) _dimensions;
	private bool _isInitialized;

	private Exception _exception = new Exception("Not initialized");

	public ObjectBuilder Init() {
		try {
			if (!File.Exists(path))
				throw new FileNotFoundException("File not found", path);
			var fileInfo = new FileInfo(path);
			_name = fileInfo.Name;
			_extension = fileInfo.Extension;
			_size = (ulong)fileInfo.Length;
			_isImage = IsImage();
			_dimensions = _isImage ? GetDimensions(path) : default;
			
			_isInitialized = true;
		}
		catch (Exception e) {
			_exception = e;
		}
		return this;
	}

	public Result<Object, Exception> Build() {
		if (_isInitialized)
			return Result<Object, Exception>.Ok(new Object(
				_name, path, _extension, _size, _isImage, _dimensions
			));
		return Result<Object, Exception>.Err(_exception);


	}
	
	private bool IsImage() => _extension?.ToLower() switch
	{
		".jpg" => true,
		".jpeg" => true,
		".png" => true,
		".gif" => true,
		".bmp" => true,
		".tiff" => true,
		".ico" => true,
		_ => false
	};
	private static (uint, uint) GetDimensions(string path) {
		#pragma warning disable CA1416
		using Image image = Image.FromFile(path);
		return ((uint, uint))(image.Width, image.Height);
		#pragma warning restore CA1416
	}
}