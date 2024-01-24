using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ImageUtopia.Services;
using ImageUtopia.ViewModels;
using ImageUtopia.Views;

namespace ImageUtopia;

public partial class App : Application
{
	public override void Initialize() {
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted() {
		var imageLoader = new ImageServices();
		var folderServices = new FolderServices();
		var mainViewModel = new MainWindowViewModel(imageLoader, folderServices);
		
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
			desktop.MainWindow = new MainWindow
			{
				DataContext = mainViewModel,
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}