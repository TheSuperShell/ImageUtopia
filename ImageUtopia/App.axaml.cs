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
		var mainViewModel = new MainWindowViewModel(imageLoader);
		
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
			desktop.MainWindow = new MainWindow
			{
				DataContext = mainViewModel,
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}