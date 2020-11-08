using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    [SerializeField] Animation anim;
    [SerializeField] Freezer freezer;
    bool isOpen = false;

    [SerializeField] AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        if (!isOpen)
            StartCoroutine(OpenTheFridge());
        else
            CloseFridge();
    }

    IEnumerator OpenTheFridge()
    {
        if (freezer.IsOpen())
        {
            freezer.CloseFreezer();
            yield return new WaitForSeconds(anim["freezer_close"].length * anim["freezer_close"].speed);
        }
        else
            yield return 0;
        OpenFridge();
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OpenFridge()
    {
        anim.Play("fridge_open");
        isOpen = true;
    }

    public void CloseFridge()
    {
        anim.Play("fridge_close");
        isOpen = false;
        linkedTask.done = true;
        StartCoroutine(CloseSound());
    }

    IEnumerator CloseSound()
    {
        yield return new WaitForSeconds(1.15f);
        audio.Play();
    }
}
