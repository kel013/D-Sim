using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Interactable
{
    [SerializeField] Animation anim;
    AudioSource audio;

    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        if (!isOpen)
        {
            anim.Play("microwave_open");
            audio.Stop();
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
        isOpen = !isOpen;
    }

    IEnumerator CloseDoor()
    {
        anim.Play("microwave_close");
        linkedTask.done = true;
        yield return new WaitForSeconds(1.3f);
        audio.Play();
    }
}
