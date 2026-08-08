using Godot;
using System;

public partial class DeleteStepButton : Button
{
    [Export] public TextViwer TextViwer { get; set; }

    public void OnPressed()
    {
        if (TextViwer.MaxNumber <= 1)
            return;
        if (TextViwer.CurrentNumber < Global.DialogueData.CurrentDialogue.Speech.Count)
        {
            Global.DialogueData.CurrentDialogue.Speech.RemoveAt(TextViwer.CurrentNumber);
        }
        else
        {
            Global.DialogueData.CurrentDialogue.Options.RemoveAt(TextViwer.CurrentNumber - Global.DialogueData.CurrentDialogue.Speech.Count);
        }
        Global.DialogueData.CurrentDialogue = Global.DialogueData.CurrentDialogue;
    }
}
