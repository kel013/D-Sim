using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    [SerializeField] Animation anim;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        StartCoroutine(BrushTeeth());
    }

    IEnumerator BrushTeeth()
    {
        audio.Play();
        yield return new WaitForSeconds(6.5f);
        anim.Play("Take 001");
        linkedTask.done = true;
    }
}
