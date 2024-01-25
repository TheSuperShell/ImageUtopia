using ImageUtopia.Utils;

namespace ImageUtopia.Models;

public record Folder(string Id, string Name, uint ImageCount, uint Size, string Description, bool SystemFolder)
{
	public string SizeFormatted => BytesFormatters.FormatBytes(Size);
};