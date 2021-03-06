﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletFlush : Interactable
{
    [SerializeField] Animation anim;
    [SerializeField] Toilet toilet;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (anim.isPlaying)
            return;

        StartCoroutine(FlushToilet());
    }

    IEnumerator FlushToilet()
    {
        if (!toilet.IsOpen())
        {
            toilet.OpenToilet();
            yield return new WaitForSeconds(anim["toilet_Open"].length * anim["toilet_Open"].speed);
        }
        else
            yield return 0;
        anim.Play("flush");
        audio.Play();

        linkedTask.done = true;
    }
}
