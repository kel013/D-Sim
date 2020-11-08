using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : Interactable
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    public override void Interact()
    {
        foreach (Transform child in player.transform)
        {
            if (child.gameObject.CompareTag("Trashbag"))
            {
                child.gameObject.SetActive(false);
                linkedTask.done = true;
            }
        }
    }
}
