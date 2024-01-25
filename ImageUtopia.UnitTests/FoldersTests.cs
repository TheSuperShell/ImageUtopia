using ImageUtopia.Models;
using System.Text.Json;

namespace ImageUtopia.UnitTests;

public class FoldersTests
{
	[Test]
	public async Task MetadataLoaderNoFileTest() {
		var metadataLoader = new MetadataLoader();
		var folders = await metadataLoader.GetFolders("empty.json");
		Assert.That(File.Exists("empty.json"), Is.True);
		File.Delete("empty.json");
		Assert.That(folders, Is.Empty);
	}
	
	[Test]
	public async Task MetadataLoaderLoadTest() {
		// Create a test file
		await using FileStream createStream = File.Create("test.json");
		await JsonSerializer.SerializeAsync(createStream, new Metadata(folders:
		[
			new FolderMetadata
			{
				Id = "1",
				Name = "Folder 1",
				Description = "Folder 1",
				ImageCount = 10,
				Size = 1204123
			},
			new FolderMetadata
			{
				Id = "2",
				Name = "Folder 2",
				Description = "Folder 2",
				ImageCount = 0,
				Size = 0
			},
			new FolderMetadata
			{
				Id = "3",
				Name = "Folder 3",
				Description = "Folder 3",
				ImageCount = 0,
				Size = 0
			}
		]));
		createStream.Close();
		
		var metadataLoader = new MetadataLoader();
		var folders = (await metadataLoader.GetFolders("test.json")).ToList();
		// Cleanup
		File.Delete("test.json");
		
		Assert.Multiple(() => {
			Assert.That(folders.Count, Is.EqualTo(3));
			Assert.That(folders[0].Id, Is.EqualTo("1"));
			Assert.That(folders[2].Name, Is.EqualTo("Folder 3"));
		});
	}

	[Test]
	public async Task MetadataLoaderUpdateTest() {
		// Create a test file
		await using FileStream createStream = File.Create("test_update.json");
		await JsonSerializer.SerializeAsync(createStream, new Metadata(folders:
		[
			new FolderMetadata
			{
				Id = "1",
				Name = "Folder 1",
				Description = "Folder 1",
				ImageCount = 10,
				Size = 1204123
			}
		]));
		createStream.Close();
		
		var metadataLoader = new MetadataLoader();
		await metadataLoader.UpdateFolder("test_update.json", new Folder(
			"1",
			"Folder 1",
			50,
			1204123,
			"Folder 1",
			false));
		await metadataLoader.UpdateFolder("test_update.json", new Folder(
			"2",
			"Folder 2",
			0,
			0,
			"Folder 2",
			false));
		
		Assert.Pass();
	}
}