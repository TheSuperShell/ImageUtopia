using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using CommunityToolkit.Mvvm.ComponentModel;
using ImageUtopia.Models;
using ImageUtopia.Services;
using ImageUtopia.Utils;
using ReactiveUI;

namespace ImageUtopia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	private readonly ImageServices _imageLoader;
	private readonly FolderServices _folderServices;
	
	private ObservableCollection<Object> _allImages = [];
	[ObservableProperty]
	private ObservableCollection<ImageViewModel> _images = [];

	[ObservableProperty]
	private ObservableCollection<Folder> _mainFolders = [];
	[ObservableProperty]
	private ObservableCollection<Folder> _userFolders = [];

	private void LoadFolders() {
		MainFolders = new ObservableCollection<Folder>(_folderServices.GetMainFolders());
		UserFolders = new ObservableCollection<Folder>(_folderServices.GetUserFolders());
	}
	
	private async void LoadImages() {
		var results = await _imageLoader.LoadImagesAsync(@"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages");
		_allImages = new ObservableCollection<Object>(results.ResultOrDebug());
		
		foreach (Object image in _allImages) {
            Images.Add(new ImageViewModel(image));
		}

		foreach (var image in Images) {
			await image.LoadImage();
		}
	}
	
	public MainWindowViewModel(ImageServices imageLoader, FolderServices folderServices) {
		_imageLoader = imageLoader;
		_folderServices = folderServices;
		LoadFolders();
		RxApp.MainThreadScheduler.Schedule(LoadImages);
	}

	public MainWindowViewModel() : this(new ImageServices(), new FolderServices()) { }
}