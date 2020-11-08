﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : Interactable
{
    public List<string> messageList = new List<string>();
    int currentMessage;
    public Text textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentMessage = 0;
        textDisplay.text = messageList[currentMessage];
    }

    public override void Interact()
    {
        if (messageList.Count <= 0)
            return;

        if (currentMessage >= messageList.Count-1)
            currentMessage = 0;
        else
            currentMessage++;

        textDisplay.text = messageList[currentMessage];
    }
}