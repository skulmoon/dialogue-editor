using Godot;
using System;

public abstract partial class DialoguePartControl : Control
{
    public abstract void SaveDialogueStep(int number, NPCDialogue dialogue);
    public abstract void LoadDialogueStep(int number, NPCDialogue dialogue);
}
