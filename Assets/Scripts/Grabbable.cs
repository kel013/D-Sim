using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    [SerializeField]
    GameObject player;
    GameObject prevPar;
    bool grabbed = false;
    Rigidbody rb;

    private void Start()
    {
        grabbed = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        
        if(grabbed)
        {
            grabbed = false;
            this.gameObject.transform.parent = prevPar.transform;
            rb.isKinematic = false;
        }
        else
        {
            grabbed = true;
            prevPar = this.gameObject.transform.parent.gameObject;
            this.gameObject.transform.parent = player.transform;
            rb.isKinematic = true;
        }
    }
}
