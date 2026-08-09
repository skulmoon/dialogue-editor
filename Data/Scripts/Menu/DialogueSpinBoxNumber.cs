using Godot;
using System;

public partial class DialogueSpinBoxNumber : OptionButton
{
    private NPCDialogue _dialogue;

    [Export] public TextViwer TextViwer { get; set; }

    public override void _EnterTree()
    {
        Global.DialogueData.CurrentDialogueCanged += OnDialoguesChanged;
        TextViwer.NumberChanged += OnNumberChanged;
        base._EnterTree();
    }

    public void OnDialoguesChanged(NPCDialogue dialogue)
    {
        _dialogue = dialogue;
        Clear();
        if (dialogue.Speech != null)
        {
            for (int i = 0; i < dialogue.Speech.Count; i++)
                AddItem($"{i} - {dialogue.Speech[i]?.Text ?? string.Empty}");
        }
        if (dialogue.Options != null)
        {
            for (int i = 0; i < dialogue.Options.Count; i++)
                AddItem($"*{i + dialogue.Speech.Count} - {dialogue.Options[i]?.OptionText ?? string.Empty}");
        }
    }

    public void OnNumberChanged(int number)
    {
        OnDialoguesChanged(_dialogue);
        Select(number);
    }

    public void OnItemSelected(int id)
    {
        TextViwer.SaveDialogueStep(TextViwer.CurrentNumber);
        TextViwer.CurrentNumber = id;
    }
}
