using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable // BREADTIMEEE
{
    TaskController taskController;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        taskController = GameObject.FindWithTag("Manager").GetComponent<TaskController>();
        audio = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        onInteract?.Invoke();
        if (taskController.AllTasksDone())
        {
            Debug.Log("next day");
            audio.Play();
            taskController.ResetAll();
        }
    }
}
