using Godot;
using System;
using System.Collections.Generic;

public partial class DialogueOptionsControl : DialoguePartControl
{
    [Export] public TextEdit Text { get; set; }
    [Export] public SpinBox NextDialogue { get; set; }
    [Export] public TextEdit Changes { get; set; }
    [Export] public TextEdit Condition { get; set; }

    public override void LoadDialogueStep(int number, NPCDialogue dialogue)
    {
        Text.Text = dialogue?.Options[number]?.OptionText ?? string.Empty;
        NextDialogue.Value = dialogue?.Options[number]?.NextDialogue ?? -1;
        Changes.Text = dialogue?.Options[number]?.Changes ?? string.Empty;
        Condition.Text = dialogue?.Options[number]?.Condition ?? string.Empty;
    }

    public override void SaveDialogueStep(int number, NPCDialogue dialogue)
    {
        if (dialogue != null && dialogue.Options.Count > number)
        {
            if (Text.Text != string.Empty)
            {
                if (dialogue.Options[number] == null)
                    dialogue.Options[number] = new Option();
                dialogue.Options[number].OptionText = Text.Text;
                dialogue.Options[number].NextDialogue = (int)NextDialogue.Value;
                dialogue.Options[number].Changes = Changes.Text;
                dialogue.Options[number].Condition = Condition.Text;
            }
            else
                dialogue.Options[number] = null;
        }
    }
}
