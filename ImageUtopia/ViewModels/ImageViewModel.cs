using System.IO;
using System.Threading.Tasks;
using ImageUtopia.Models;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ImageUtopia.ViewModels;

public partial class ImageViewModel(Object @object) : ViewModelBase
{
	[ObservableProperty]
	private Bitmap? _image;

	[ObservableProperty] 
	private bool _show;
	
	public string Name => @object.Name;

	[RelayCommand]
	public async Task LoadImage() {
		var image = await @object.LoadImage();
		if (image.IsNone) return;
		await using (Stream imageStream = image.Unwrap()) {
			Image = new Bitmap(imageStream);
		}
		Show = true;
	}
	
}