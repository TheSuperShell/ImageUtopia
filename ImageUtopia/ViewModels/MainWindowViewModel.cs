﻿using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageUtopia.Models;
using ImageUtopia.Services;
using ImageUtopia.Utils;
using ReactiveUI;

namespace ImageUtopia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	private readonly ImageServices _imageLoader;
	
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
		var results = await _imageLoader.LoadImagesAsync(@"C:\Users\User\Documents\NET Projects\ImageUtopiaApp\TestImages");
        AllImages = new ObservableCollection<Object>(results.ResultOrDebug());
	}
	
	private async void LoadImagesOnStartUp() => await LoadImages();
	
	public MainWindowViewModel(ImageServices imageLoader) {
		_imageLoader = imageLoader;
		RxApp.MainThreadScheduler.Schedule(LoadImagesOnStartUp);
	}

	public MainWindowViewModel() {
		_imageLoader = new ImageServices();
		RxApp.MainThreadScheduler.Schedule(LoadImagesOnStartUp);
	}
}