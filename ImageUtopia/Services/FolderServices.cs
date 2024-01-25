using System.Collections.Generic;
using ImageUtopia.Models;

namespace ImageUtopia.Services;

public class FolderServices
{
	public IEnumerable<Folder> GetMainFolders() =>
	[
		new Folder( "", "All", 10, 1204123, "All images", true),
		new Folder("", "Uncategorized", 0, 0, "Images without a folder", true),
		new Folder("", "Random", 0, 0, "Random images", true)
	];
	
	public IEnumerable<Folder> GetUserFolders() =>
	[
		new Folder("", "Folder 1", 10, 1204123, "Folder 1", false),
		new Folder("", "Folder 2", 0, 0, "Folder 2", false),
		new Folder("", "Folder 3", 0, 0, "Folder 3", false)
	];
}