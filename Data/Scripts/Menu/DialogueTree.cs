using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class DialogueTree : Tree
{
    [Export] public PopupMenu Menu { get; set; }

    public override void _Ready()
    {
        Global.DialogueData.DialoguesChanged += OnDialogueChanged;
        base._Ready();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Right)
        {
            Menu.Popup(new Rect2I((Vector2I)mouseEvent.GlobalPosition, new Vector2I(0, 0)));
        }
    }

    public void OnDialogueChanged(Dictionary<string, List<NPCDialogue>> dialogues)
    {
        Clear();
        TreeItem root = CreateItem();
        foreach (var dialogue in dialogues)
        {
            TreeItem location = CreateItem(root);
            location.SetText(0, dialogue.Key);
            List<TreeItem> npcs = new List<TreeItem>();
            foreach (var locationDialogue in dialogue.Value)
            {
                string npcName = Global.DialogueData.GetNPCName(locationDialogue.NPCID);
                TreeItem npcItem = npcs.Find(x => x.GetText(0) == npcName);
                if (npcItem == null)
                {
                    npcItem = CreateItem(location);
                    npcItem.SetText(0, npcName);
                    npcItem.SetTooltipText(0, locationDialogue.NPCID.ToString());
                    npcs.Add(npcItem);
                }
                TreeItem dialogueNpcItem = CreateItem(npcItem);
                dialogueNpcItem.SetText(0, locationDialogue.DialogueNumber.ToString());
            }
        }
    }

    public void OnCellSelected()
    {
        TreeItem currentItem = GetSelected();
        if (currentItem != null)
        {
            if (int.TryParse(currentItem.GetText(0), out int result))
            {
                string location = currentItem.GetParent().GetParent().GetText(0);
                int npcId = int.Parse(currentItem.GetParent().GetTooltipText(0));
                List<NPCDialogue> dialogues = Global.DialogueData.Dialogues[location];
                NPCDialogue dialogue = dialogues.Find(x => x.NPCID == npcId && x.DialogueNumber == result);
                Global.DialogueData.CurrentDialogue = dialogue;
            }
        }
    }
}
