using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable // BREADTIMEEE
{
    TaskController taskController;
    // Start is called before the first frame update
    void Start()
    {
        taskController = GameObject.FindWithTag("Manager").GetComponent<TaskController>();
    }

    public override void Interact()
    {
        onInteract?.Invoke();
        if (taskController.AllTasksDone())
        {
            Debug.Log("next day");
            taskController.ResetAll();
        }
    }
}
