using Godot;
using System;

public partial class Global : Node
{
    public static Variables Variables { get; private set; }
    public static JSON JSON { get; private set; }

    public Global()
    {
        ProcessPriority = 10;
        Variables = new Variables();
        JSON = new JSON();
    }
}
