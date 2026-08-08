using Godot;
using System;

public partial class Global : Node
{
    public static DialogueData DialogueData { get; private set; }
    public static JSON JSON { get; private set; }

    public Global()
    {
        ProcessPriority = 10;
        DialogueData = new DialogueData();
        JSON = new JSON();
    }
}
