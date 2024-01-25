using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ImageUtopia.Utils;

namespace ImageUtopia.Models;

public class MetadataLoader
{
	private static async Task<Result<Metadata, Exception>> DeserializeMetadata(string jsonPath) {
		try {
			await using FileStream w = File.Exists(jsonPath) ? File.OpenRead(jsonPath) : File.Create(jsonPath);
			var metadata = await JsonSerializer.DeserializeAsync<Metadata>(w);
			if (metadata is not null)
				return metadata;
			metadata = new Metadata();
			await SerializeMetadata(jsonPath, metadata);
			return metadata;
		} catch (Exception e) {
			return e;
		}
	}
	
	private static async Task SerializeMetadata(string jsonPath, Metadata metadata) {
		try {
			await using FileStream createStream = File.Create(jsonPath);
			await JsonSerializer.SerializeAsync(createStream, metadata);
		} catch (Exception e) {
			Debug.WriteLine(e);
		}
	}
	
	
	public async Task<IEnumerable<Folder>> GetFolders(string path) {
		var result = await DeserializeMetadata(path);
		if (result.IsErr) {
			Debug.WriteLine(result.UnwrapErr());
			return [];
		}
		var metadata = result.Unwrap();
		var folders = new List<Folder>();
		foreach (var folder in metadata.Folders) {
			folders.Add(new Folder(
				folder.Id,
				folder.Name,
				folder.ImageCount,
				folder.Size,
				folder.Description,
				false));
		}
		return folders;
	} 
	
	public async Task UpdateFolder(string path, Folder folderToUpdate) {
		if (folderToUpdate.SystemFolder) {
			Debug.WriteLine("Cannot update system folder");
			return;
		}
		
		var result = await DeserializeMetadata(path);
		if (result.IsErr) {
			Debug.WriteLine(result.UnwrapErr());
			return;
		}
		var metadata = result.Unwrap();
		var folderToChange = metadata.Folders.Find(f => f.Id == folderToUpdate.Id);
		if (folderToChange is not null) {
			var index = metadata.Folders.IndexOf(folderToChange);
			metadata.Folders[index] = FolderMetadata.FromFolder(folderToUpdate);
		}
		else {
			metadata.Folders.Add(FolderMetadata.FromFolder(folderToUpdate));
		}
		await SerializeMetadata(path, metadata);
	}
}