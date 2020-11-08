using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Interact()
    {
        linkedTask.done = true;
    }
}
