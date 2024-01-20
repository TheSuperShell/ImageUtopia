using Avalonia;
using Avalonia.Controls.Primitives;

namespace ImageUtopia.Controls;

public class FolderButtonTemplate : ToggleButton
{
	public static readonly StyledProperty<bool> IsSelectedProperty =
		AvaloniaProperty.Register<FolderButtonTemplate, bool>(nameof(IsSelected), false);
	public static readonly StyledProperty<string> FolderNameProperty =
		AvaloniaProperty.Register<FolderButtonTemplate, string>(nameof(FolderName), "Folder Name");
	public static readonly StyledProperty<string> FolderCountProperty =
		AvaloniaProperty.Register<FolderButtonTemplate, string>(nameof(FolderCount), 0.ToString());
	
	public string FolderName {
		get => GetValue(FolderNameProperty);
		set => SetValue(FolderNameProperty, value);
	}
	
	public string FolderCount {
		get => GetValue(FolderCountProperty);
		set => SetValue(FolderCountProperty, value);
	}

	public bool IsSelected {
		get => GetValue(IsSelectedProperty);
		set => SetValue(IsSelectedProperty, value);
	}
}