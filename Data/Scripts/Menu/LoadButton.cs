using Godot;
using System;

public partial class LoadButton : Button
{
	[Export] public FileDialog FileDialog { get; set; }

	public void OnPressed()
	{
        FileDialog.Show();
    }
}
