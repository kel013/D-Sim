using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    [SerializeField] Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        anim.Play("Take 001");
        linkedTask.done = true;
    }
}
