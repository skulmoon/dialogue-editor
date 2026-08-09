using Godot;
using System;

public partial class SaveButton : Button
{
	public void OnPressed()
	{
		foreach (var item in Global.DialogueData.Dialogues)
			Global.JSON.SetDialogues(item.Value, item.Key);
	}
}
