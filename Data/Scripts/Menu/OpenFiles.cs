using Godot;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class OpenFiles : FileDialog
{
    [Export] public Tree DialogueTree { get; set; }
    [Export] public SpinBox SpinBox { get; set; }

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
