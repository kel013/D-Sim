using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCycle : MonoBehaviour
{
    public List<string> messageList = new List<string>();
    int currentMessage;

    public KeyCode nextMessageKey;

    // Start is called before the first frame update
    void Start()
    {
        currentMessage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (messageList.Count <= 0)
            return;
        if (Input.GetKeyDown(nextMessageKey))
        {
            Debug.Log(messageList[currentMessage]);

            if (currentMessage >= messageList.Count-1)
                currentMessage = 0;
            else
                currentMessage++;
        }
    }
}
