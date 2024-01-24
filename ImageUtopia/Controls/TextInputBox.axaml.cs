using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ImageUtopia.Controls;

public class TextInputBox : TemplatedControl
{
	public static readonly StyledProperty<string> TextProperty = 
		AvaloniaProperty.Register<TextInputBox, string>(nameof(Text));
	
	public static readonly StyledProperty<string> WatermarkProperty = 
		AvaloniaProperty.Register<TextInputBox, string>(nameof(Watermark));
	
	public string Text {
		get => GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}
	
	public string Watermark {
		get => GetValue(WatermarkProperty);
		set => SetValue(WatermarkProperty, value);
	}
}