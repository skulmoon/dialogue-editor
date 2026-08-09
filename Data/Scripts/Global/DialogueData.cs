using Godot;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public class DialogueData
{
    private Dictionary<string, List<NPCDialogue>> _dialogues;
    private NPCDialogue _currentDialogue;

    public Dictionary<string, List<NPCDialogue>> Dialogues 
    { 
        get => _dialogues;
        set
        {
            _dialogues = value;
            DialoguesChanged?.Invoke(value);
        } 
    }

    public NPCDialogue CurrentDialogue 
    { 
        get => _currentDialogue;
        set
        {
            _currentDialogue = value;
            CurrentDialogueCanged?.Invoke(value);
        }
    }

    public event Action<Dictionary<string, List<NPCDialogue>>> DialoguesChanged;
    public event Action<NPCDialogue> CurrentDialogueCanged;

    public void LoadDialogue(Dictionary<string, List<NPCDialogue>> dialogues) =>
        Dialogues = dialogues;

    public string GetNPCName(int id)
    {
        return id switch
        {
            0 => "Игрок",
            1 => "Тестовый npc",
            2 => "Автобус",
            3 => "Камера",
            4 => "Забытый (Фалмер)",
            5 => "Святогор",
            6 => "Берлих",
            7 => "Грегор",
            8 => "Роблиф",
            _ => "unknow" + id,
        };
    }

    public void UpdateDialogues() =>
        Dialogues = Dialogues;

    public void UpdateCurrentDialogue() =>
        CurrentDialogue = CurrentDialogue;
}
