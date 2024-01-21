using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImageUtopia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
	public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

	public ObservableCollection<string> FolderNames { get; } = new([
		"Folder 1",
		"Folder 2",
		"Folder 3"
	]);
	
	public ObservableCollection<string> ImageNames { get; } = new([
		"Image 1",
		"Image 2",
		"Image 3",
		"Cats",
		"Dogs",
		"Fish",
	]);
}