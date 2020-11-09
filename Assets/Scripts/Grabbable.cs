using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    GameObject player;
    GameObject prevPar;
    bool grabbed = false;
    Rigidbody rb;
    Vector3 originalPosition;
    Quaternion originalRotation;

    AudioSource audio;
    DayController dayController;

    private void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        dayController = GameObject.FindWithTag("Manager").GetComponent<DayController>();
        dayController.grabbables.Add(this);
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

    public void ResetTransform()
    {
        if (prevPar == null)
            this.gameObject.transform.parent = null;
        else
            this.gameObject.transform.parent = prevPar.transform;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
