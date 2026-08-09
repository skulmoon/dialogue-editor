using Godot;
using System;
using System.Collections.Generic;

public partial class DialogueStepControl : DialoguePartControl
{
    [Export] public TextEdit Text { get; set; }
    [Export] public LineEdit NPCName { get; set; }
    [Export] public LineEdit Image { get; set; }
    [Export] public TextEdit Condition { get; set; }

    public override void LoadDialogueStep(int number, NPCDialogue dialogue)
    {
        Text.Text = dialogue?.Speech[number]?.Text ?? string.Empty;
        NPCName.Text = dialogue?.Speech[number]?.Name ?? string.Empty;
        Image.Text = dialogue?.Speech[number]?.Image ?? string.Empty;
        Condition.Text = dialogue?.Speech[number]?.Condition ?? string.Empty;
    }

    public override void SaveDialogueStep(int number, NPCDialogue dialogue)
    {
        if (dialogue != null)
        {
            bool isEmpty =
                Text.Text == string.Empty &&
                NPCName.Text == string.Empty &&
                Image.Text == string.Empty;
            if (!isEmpty)
            {
                if (dialogue.Speech[number] == null)
                    dialogue.Speech[number] = new IDAndText();
                dialogue.Speech[number].Text = Text.Text;
                dialogue.Speech[number].Name = NPCName.Text;
                dialogue.Speech[number].Image = Image.Text;
                dialogue.Speech[number].Condition = Condition.Text;
            }
            else
                dialogue.Speech[number] = null;
        }
    }
}
