using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class JSON
{
    private const string PATH_DIALOGUES = "res://Data/Dialogs/";
    private const string PATH_PAMS = "res://Data/PAMS/";
    private const string PATH_SAVES = "user://Saves/";
     
    private T GetJsonData<T>(string path, bool readAll = false)
    {
        FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        string json = file?.GetAsText() ?? "";
        file?.Close();
        return readAll ? JsonConvert.DeserializeObject<T>(json) : JsonConvert.DeserializeObject<T>(json);
    }

    private void SetJsonData<T>(T data, string path, bool saveAll = false)
    {
        string jsonTask = saveAll ? JsonConvert.SerializeObject(data, Formatting.Indented) : JsonConvert.SerializeObject(data, Formatting.Indented);
        FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file?.StoreString(jsonTask);
        file?.Close();
    }

    public List<NPCDialogue> GetDialogues(string path) =>
        GetJsonData<List<NPCDialogue>>(path);

    public void SetDialogues(List<NPCDialogue> dialogues, string path) =>
        SetJsonData<List<NPCDialogue>>(dialogues, path);

    public void DeleteFile(string path) =>
        System.IO.File.Delete(path);
}
