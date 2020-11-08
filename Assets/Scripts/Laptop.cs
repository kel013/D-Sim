using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : Interactable
{
    public List<string> messageList = new List<string>();
    int currentMessage;
    [SerializeField] Text textDisplay;
    [SerializeField] Animation anim;
    AudioSource audio;

    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim["laptop_Close"].speed = 5;
        anim.Play("laptop_Close");
        audio = GetComponent<AudioSource>();

        //currentMessage = 0;
        //textDisplay.text = messageList[currentMessage];
    }

    public override void Interact()
    {
        if (messageList.Count <= 0)
            return;

        if (!isOpen)
        {
            if (!anim.isPlaying)
            {
                currentMessage = 0; // loop back to beginning
                textDisplay.text = messageList[currentMessage];
                anim.Play("laptop_Open");
                isOpen = true;
            }
        }
        else
        {
            if (currentMessage >= messageList.Count - 1)
            {
                anim["laptop_Close"].speed = 1;
                anim.Play("laptop_Close");
                isOpen = false;

                linkedTask.done = true;
            }
            else
            {
                currentMessage++;
                audio.Play();
            }

            textDisplay.text = messageList[currentMessage];
        }
    }
}
