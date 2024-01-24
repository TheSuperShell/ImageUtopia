using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ImageUtopia.ViewModels;

namespace ImageUtopia.Views;

public partial class MainWindow : Window
{
	private bool _mouseDownForWindowMoving = false;
	private PointerPoint _originalPoint;

	private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
	{
		if (!_mouseDownForWindowMoving) return;

		PointerPoint currentPoint = e.GetCurrentPoint(this);
		Position = new PixelPoint(Position.X + (int)(currentPoint.Position.X - _originalPoint.Position.X),
			Position.Y + (int)(currentPoint.Position.Y - _originalPoint.Position.Y));
	}

	private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
	{
		if (WindowState is WindowState.Maximized or WindowState.FullScreen) return;

		_mouseDownForWindowMoving = true;
		_originalPoint = e.GetCurrentPoint(this);
	}

	private void InputElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
	{
		_mouseDownForWindowMoving = false;
	}
	public MainWindow() {
		InitializeComponent();
		DataContextChanged += MainWindow_DataContextChanged;
	}

	private void MainWindow_DataContextChanged(object? sender, EventArgs e) {
		if (DataContext is not MainWindowViewModel viewModel) return;
		MainFoldersListBox.SelectionChanged += (_, args) => viewModel.OnSelectedMainFolderChanged(args);
		CustomFoldersListBox.SelectionChanged += (_, args) => viewModel.OnSelectedUserFolderChanged(args);
	}
}