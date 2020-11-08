using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Interactable
{
    [SerializeField] Animation anim;

    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        linkedTask.done = true;
        return; // microwave anim has bugs
        if (anim.isPlaying)
            return;

        if (!isOpen)
            anim.Play("microwave_open");
        else
            anim.Play("microwave_close");
        isOpen = !isOpen;
    }
}
