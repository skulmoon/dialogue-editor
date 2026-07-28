using Godot;
using System;
using System.Collections.Generic;

public class Variables
{
    public int GridSize { get; private set; } = 32;
    public bool CutScene { get; set; } = false;
    public bool FistCutSceneActivated { get; set; } = false;
    public string CurrentSave { get; set; }
}
