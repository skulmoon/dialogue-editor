using Godot;
using System;

public partial class LeftButton : Button
{
    [Export] public TextViwer TextViwer { get; set; }

    public void OnPressed()
    {
        TextViwer.SaveDialogueStep(TextViwer.CurrentNumber);
        TextViwer.CurrentNumber--;
    }
}
