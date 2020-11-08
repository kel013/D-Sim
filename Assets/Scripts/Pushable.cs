using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    GameObject player;
    float force = 5;
    Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
    }
    public override void Interact()
    {
        Debug.Log("dothing");
        rb.velocity = player.transform.forward * force;
    }
}
