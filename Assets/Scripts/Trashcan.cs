using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : Interactable
{
    GameObject player;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Interact()
    {
        foreach (Transform child in player.transform)
        {
            if (child.gameObject.CompareTag("Trashbag"))
            {
                child.gameObject.SetActive(false);
                audio.Play();
                linkedTask.done = true;
            }
        }
    }
}
