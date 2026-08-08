using Godot;
using System;

public partial class AddOptionButton : Button
{
    [Export] public TextViwer TextViwer { get; set; }

    public void OnPressed()
    {
        if (TextViwer.CurrentNumber < Global.DialogueData.CurrentDialogue.Speech.Count)
        {
            Global.DialogueData.CurrentDialogue.Options.Insert(0, new Option());
            TextViwer.CurrentNumber = Global.DialogueData.CurrentDialogue.Speech.Count;
        }
        else
        {
            Global.DialogueData.CurrentDialogue.Options.Insert(TextViwer.CurrentNumber - Global.DialogueData.CurrentDialogue.Speech.Count, new Option());
        }
        Global.DialogueData.CurrentDialogue = Global.DialogueData.CurrentDialogue;
    }
}
