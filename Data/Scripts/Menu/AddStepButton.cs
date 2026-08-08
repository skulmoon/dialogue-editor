using Godot;
using System;

public partial class AddStepButton : Button
{
    [Export] public TextViwer TextViwer { get; set; }

    public void OnPressed()
    {
        int maxNumber = Global.DialogueData.CurrentDialogue.Speech.Count;
        if (TextViwer.CurrentNumber >= Global.DialogueData.CurrentDialogue.Speech.Count)
        {
            Global.DialogueData.CurrentDialogue.Speech.Insert(maxNumber, new IDAndText());
            TextViwer.CurrentNumber = maxNumber;
        }
        else
        {
            Global.DialogueData.CurrentDialogue.Speech.Insert(TextViwer.CurrentNumber, new IDAndText());
        }
        Global.DialogueData.CurrentDialogue = Global.DialogueData.CurrentDialogue;
    }
}
