namespace ImageUtopia.Utils;

public static class BytesFormatters
{
	public static string FormatBytes(uint bytes) {
		return bytes switch
		{
			< 1024 => $"{bytes} B",
			< 1024 * 1024 => $"{bytes / 1024} KB",
			< 1024 * 1024 * 1024 => $"{bytes / 1024 / 1024} MB",
			_ => $"{bytes / 1024 / 1024 / 1024} GB"
		};
	}
}