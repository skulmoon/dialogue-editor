using Godot;
using System;
using System.Collections.Generic;

public partial class AddStepButton : Button
{
    [Export] public TextViwer TextViwer { get; set; }

    public void OnPressed()
    {
        if (Global.DialogueData.CurrentDialogue.Speech == null)
            Global.DialogueData.CurrentDialogue.Speech = new List<IDAndText>();
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
        Global.DialogueData.UpdateCurrentDialogue();
    }
}
