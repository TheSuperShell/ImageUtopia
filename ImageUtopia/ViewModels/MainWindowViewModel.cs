using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageUtopia.Models;
using ImageUtopia.Services;

namespace ImageUtopia.ViewModels;

public partial class MainWindowViewModel(ImageServices imageLoader) : ViewModelBase
{
	private readonly ImageServices _imageLoader = imageLoader;
	
#pragma warning disable CA1822 // Mark members as static
	public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
	
	public ObservableCollection<string> MainFolderNames { get; } = new([
		"All",
		"Uncategorized",
		"Random",
	]);
	
	public ObservableCollection<string> FolderNames { get; } = new([
		"Folder 1",
		"Folder 2",
		"Folder 3"
	]);
	
	[ObservableProperty]
	private ObservableCollection<Object> _allImages = [new Object("default", "default", "", default, default, default)];
	
	[RelayCommand]
	private async Task LoadImages() {
        AllImages = new ObservableCollection<Object>(await _imageLoader.LoadImagesAsync(@"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages"));
	}

	public MainWindowViewModel() : this(new ImageServices()) {
	}
}