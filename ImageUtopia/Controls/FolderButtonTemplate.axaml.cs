using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ImageUtopia.Controls;

public class FolderButtonTemplate : TemplatedControl
{
	public static readonly StyledProperty<string> FolderNameProperty =
		AvaloniaProperty.Register<FolderButtonTemplate, string>(nameof(FolderName), "Folder Name");
	public static readonly StyledProperty<int> FolderCountProperty =
		AvaloniaProperty.Register<FolderButtonTemplate, int>(nameof(FolderCount), 0);
	
	public string FolderName {
		get => GetValue(FolderNameProperty);
		set => SetValue(FolderNameProperty, value);
	}
	
	public int FolderCount {
		get => GetValue(FolderCountProperty);
		set => SetValue(FolderCountProperty, value);
	}
}