using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : Interactable
{
    [SerializeField]
    DialogDisplay display;
    [SerializeField]
    Dialog[] dialogSet;

    int currentLines = 0;
    public override void Interact()
    {
        display.DisplayDialog(dialogSet[currentLines].lines);
        if (currentLines < dialogSet.Length - 1)
        {
            currentLines++;
        }
        linkedTask.done = true;
    }
}
