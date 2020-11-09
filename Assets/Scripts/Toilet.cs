using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Interactable
{
    [SerializeField] Animation anim;

    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        if (!isOpen)
            OpenToilet();
        else
            CloseToilet();
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OpenToilet()
    {
        anim.Play("toilet_Open");
        isOpen = true;
    }

    public void CloseToilet()
    {
        anim.Play("toilet_Close");
        isOpen = false;
    }

    public override void Reset()
    {
        CloseToilet();
    }
}
