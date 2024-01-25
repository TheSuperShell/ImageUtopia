using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageUtopia.Models;

namespace ImageUtopia.Services;

public class FolderServices
{
	private MetadataLoader _metadataLoader;
	private List<Folder> _allFolders = [];
	
	public IEnumerable<Folder> MainFolders => _allFolders.Where(folder => folder.SystemFolder);
	public IEnumerable<Folder> UserFolders => _allFolders.Where(folder => !folder.SystemFolder);

	public async Task LoadAllFolders() {
		_metadataLoader = new MetadataLoader();
		_allFolders.AddRange(GetMainFolders());
		_allFolders.AddRange(await _metadataLoader.GetFolders("metadata.json"));
	}
	
	public async Task UpdateFolder(Folder folderToUpdate) {
		var folder = _allFolders.FirstOrDefault(f => f.Id == folderToUpdate.Id);
		if (folder is null) {
			_allFolders.Add(folderToUpdate);
		} else {
			var index = _allFolders.IndexOf(folder);
			_allFolders[index] = folderToUpdate;
		}
		await _metadataLoader.UpdateFolder("metadata.json", folderToUpdate);
	}
	
	private IEnumerable<Folder> GetMainFolders() =>
	[
		new Folder( "", "All", 0, 0, "", true),
		new Folder("", "Uncategorized", 0, 0, "", true),
		new Folder("", "Random", 0, 0, "", true)
	];
}