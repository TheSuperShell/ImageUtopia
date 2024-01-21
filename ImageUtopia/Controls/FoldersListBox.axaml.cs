using System;
using Avalonia.Controls;

namespace ImageUtopia.Controls;

public partial class FoldersListBox : ListBox
{
	public FoldersListBox() {
		InitializeComponent();
	}


	protected override Type StyleKeyOverride => typeof(ListBox);
}