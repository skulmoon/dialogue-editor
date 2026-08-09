using Godot;
using System;
using System.Collections.Generic;

public partial class ButtonCreateDialogue : Button
{
    [Export] public LineEdit File { get; set; }
    [Export] public SpinBox NPCID { get; set; }
    [Export] public SpinBox DialogueNumber { get; set; }

    public void OnPressed()
    {
        try
        {
            Dictionary<string, List<NPCDialogue>> dialogues = Global.DialogueData.Dialogues;
            NPCDialogue dialogue = new NPCDialogue
            {
                NPCID = (int)NPCID.Value,
                DialogueNumber = (int)DialogueNumber.Value,
                Speech = new List<IDAndText>() { new IDAndText() }
            };
            bool isContain = false;
            foreach(var item in dialogues)
            {
                if (item.Key == File.Text)
                {
                    isContain = true;
                    item.Value.Add(dialogue);
                }
            }
            if (!isContain)
            {
                dialogues.Add(File.Text, new List<NPCDialogue> { dialogue });
            }
            Global.DialogueData.UpdateDialogues();
        }
        catch
        {
            GD.Print($"The dialogue (NPCID: {NPCID.Value}, DialogueNumber: {DialogueNumber.Value}) cant be added.");
        }
    }
}
