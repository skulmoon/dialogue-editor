using Godot;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class OpenFiles : FileDialog
{
    [Export] public Tree DialogueTree { get; set; }
    [Export] public SpinBox SpinBox { get; set; }

    public override void _Ready()
    {
        OnFileSelected("C:\\Материалы для игр\\TheWillofCrystal\\Data\\Dialogs\\ru\\Chapter1\\SkeletonBase.json");
        base._Ready();
    }

    public void OnFileSelected(string path) =>
        OnFilesSelected(new string[] { path });

    public void OnFilesSelected(string[] paths)
    {
        var dictionary = new Dictionary<string, List<NPCDialogue>>();
        foreach(string path in paths)
        {
            List<NPCDialogue> dialogues = Global.JSON.GetDialogues(path);
            string file = path.Split('/')[^1];
            dictionary.Add(file, dialogues);
        }
        Global.DialogueData.LoadDialogue(dictionary);
    }
}
