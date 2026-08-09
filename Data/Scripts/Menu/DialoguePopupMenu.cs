using Godot;
using System;
using System.Collections.Generic;

public partial class DialoguePopupMenu : PopupMenu
{
    [Export] public DialogueTree DialogueTree { get; set; }
    [Export] public LineEdit File { get; set; }
    [Export] public SpinBox NPCID { get; set; }
    [Export] public SpinBox DialogueNumber { get; set; }

    public void OnIdPressed(int id)
    {
        TreeItem item = DialogueTree.GetItemAtPosition(Position);
        if (id == 0)
        {
            if (item != null)
            {
                if (int.TryParse(item.GetText(0), out int textResult))
                {
                    File.Text = item.GetParent().GetParent().GetText(0);
                    NPCID.Value = int.Parse(item.GetParent().GetTooltipText(0));
                    DialogueNumber.Value = int.Parse(item.GetText(0));
                }
                else if (int.TryParse(item.GetTooltipText(0), out int tooltipResult))
                {
                    File.Text = item.GetParent().GetText(0);
                    NPCID.Value = int.Parse(item.GetTooltipText(0));
                }
                else
                {
                    File.Text = item.GetText(0);
                }
            }
            DialogueTree.GetNode<Panel>("Panel").Show();
        }
        else if (id == 1)
        {
            if (item != null)
            {
                if (int.TryParse(item.GetText(0), out int textResult))
                {
                    List<NPCDialogue> dialogues = Global.DialogueData.Dialogues[item.GetParent().GetParent().GetText(0)];
                    dialogues.RemoveAll(x =>
                    (x.NPCID == int.Parse(item.GetParent().GetTooltipText(0))) &&
                    (x.DialogueNumber == int.Parse(item.GetText(0))));
                }
                else if (int.TryParse(item.GetTooltipText(0), out int tooltipResult))
                {
                    List<NPCDialogue> dialogues = Global.DialogueData.Dialogues[item.GetParent().GetText(0)];
                    dialogues.RemoveAll(x => x.NPCID == int.Parse(item.GetParent().GetTooltipText(0)));
                }
                else
                {
                    Global.DialogueData.Dialogues.Remove(item.GetText(0));
                }
            }
            Global.DialogueData.UpdateDialogues();
        }
    }

    public void OnPopupHide()
    {
        GuiReleaseFocus();
    }
}
