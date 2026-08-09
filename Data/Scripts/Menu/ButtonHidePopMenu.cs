using Godot;
using System;

public partial class ButtonHidePopMenu : Button
{
    [Export] public Panel Panel { get; set; }

    public void OnPressed() =>
        Panel.Hide();
}
