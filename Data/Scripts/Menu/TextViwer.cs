using Godot;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class TextViwer : Control
{
    private NPCDialogue _dialogue;
    private int _currentNumber = 0;

    public int MaxNumber { get => (_dialogue?.Speech?.Count ?? 0) + (_dialogue?.Options?.Count ?? 0) - 1; }
    public bool IsCurrenSpeech { get => _currentNumber < (_dialogue?.Speech?.Count ?? 0); }
    [Export] public DialogueStepControl StepControl { get; set; }
    [Export] public DialogueOptionsControl OptionsControl { get; set; }

    public int CurrentNumber 
    { 
        get => _currentNumber;
        set
        {
            if (_dialogue != null)
            {
                if (value < 0)
                    _currentNumber = MaxNumber;
                else if (value > MaxNumber)
                    _currentNumber = 0;
                else
                    _currentNumber = value;
                NumberChanged?.Invoke(_currentNumber);
                LoadDialogueStep(_currentNumber);
            }
        } 
    }

    public event Action<int> NumberChanged;

    public override void _Ready()
    {
        Global.DialogueData.CurrentDialogueCanged += OnCurrentDialogueCanged;
        base._Ready();
    }

    public void OnCurrentDialogueCanged(NPCDialogue dialogue)
    {
        if (_dialogue != null)
            SaveDialogueStep(_currentNumber);
        _dialogue = dialogue;
        if (MaxNumber > CurrentNumber)
            CurrentNumber = CurrentNumber;
        else
            CurrentNumber = MaxNumber;
    }

    public void SaveDialogueStep(int number)
    {
        if (!IsCurrenSpeech)
        {
            int optionNumber = number - _dialogue.Speech.Count;
            OptionsControl.SaveDialogueStep(optionNumber, _dialogue);
        }
        else
            StepControl.SaveDialogueStep(number, _dialogue);
        GD.Print(1);
    }

    public void LoadDialogueStep(int number)
    {
        if (!IsCurrenSpeech)
        {
            StepControl.Hide();
            OptionsControl.Show();
            int optionNumber = number - _dialogue.Speech.Count;
            OptionsControl.LoadDialogueStep(optionNumber, _dialogue);
        }
        else
        {
            StepControl.Show();
            OptionsControl.Hide();
            StepControl.LoadDialogueStep(number, _dialogue);
        }
    }
}
