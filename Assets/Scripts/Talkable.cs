using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : Interactable
{
    [SerializeField]
    DialogDisplay display;
    [SerializeField]
    Dialog dialog;
    public override void Interact()
    {
        display.DisplayDialog(dialog.lines);
        linkedTask.done = true;
    }
}
