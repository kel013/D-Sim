using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable // BREADTIMEEE
{
    TaskController taskController;
    // Start is called before the first frame update
    void Start()
    {
        taskController = GameObject.Find("Manager").GetComponent<TaskController>();
    }

    public override void Interact()
    {
        if (taskController.AllTasksDone())
        {
            taskController.ResetAll();
        }
    }
}
