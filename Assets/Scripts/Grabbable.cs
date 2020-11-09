using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    GameObject player;
    GameObject prevPar;
    bool grabbed = false;
    Rigidbody rb;

    AudioSource audio;

    private void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        grabbed = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        audio = player.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if(grabbed)
        {
            grabbed = false;
            if (prevPar == null)
                this.gameObject.transform.parent = null;
            else
                this.gameObject.transform.parent = prevPar.transform;
            rb.isKinematic = false;
        }
        else
        {
            audio.Play();
            grabbed = true;
            if (transform.parent != null)
                prevPar = this.gameObject.transform.parent.gameObject;
            this.gameObject.transform.parent = player.transform;
            rb.isKinematic = true;
        }
    }
}
