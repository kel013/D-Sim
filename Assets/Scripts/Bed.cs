using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable // BREADTIMEEE
{
    GameObject manager;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
        audio = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        onInteract?.Invoke();
        if (manager.GetComponent<TaskController>().AllTasksDone())
        {
            Debug.Log("next day");
            audio.Play();
            manager.GetComponent<DayController>().NextDay();
        }
    }
}
