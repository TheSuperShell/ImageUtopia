using System.Collections.Generic;

namespace ImageUtopia.Models;

public class Metadata
{
	public Metadata() {
	}

	public Metadata(List<FolderMetadata> folders) {
		Folders = folders;
	}

	public List<FolderMetadata> Folders { get; set; } = [];
}

public class FolderMetadata
{
	public string Id { set; get; }
	public string Name { get; set; }
	public string Description { get; set; }
	public uint ImageCount { get; set; }
	public uint Size { get; set; }
	
	public static FolderMetadata FromFolder(Folder folder) {
		return new FolderMetadata {
			Id = folder.Id,
			Name = folder.Name,
			Description = folder.Description,
			ImageCount = folder.ImageCount,
			Size = folder.Size
		};
	}
}