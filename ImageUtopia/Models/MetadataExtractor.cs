using System;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Shell;

namespace ImageUtopia.Models;

public class MetadataExtractor(string path)
{
	private readonly ShellFile? _shellFile = ShellFile.FromFilePath(path);
	
	public readonly string Path = path;
	public bool IsValidFile => _shellFile is not null;
	public string Name => _shellFile?.Properties.System.FileName.Value ?? string.Empty;
	public string Extension => _shellFile?.Properties.System.FileExtension.Value ?? string.Empty;
	public ulong Size => _shellFile?.Properties.System.Size.Value ?? 0;
	public bool IsImage => _shellFile?.Properties.System.Image is not null;
	public (uint, uint) Dimensions
	{
		get
		{
			string? rawString = _shellFile?.Properties.System.Image?.Dimensions.Value;
			if (rawString is null || rawString.Length <= 2) return default;
			string dimensions = rawString.Substring(1, rawString.Length - 2);
			try {
				return (uint.Parse(dimensions.Split('x')[0].Trim()), uint.Parse(dimensions.Split('x')[1].Trim()));
			}
			catch (Exception e) {
				Debug.WriteLine($"Error while parsing dimensions: {e.Message}");
				return default;
			}
		}
	}
		
}