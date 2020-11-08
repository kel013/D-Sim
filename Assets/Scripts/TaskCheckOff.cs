using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckOff : Interactable
{
    [SerializeField]
    int taskNumber;
    [SerializeField]
    TaskController taskController;

    private void Start()
    {
        if (taskController == null)
        {
            taskController = FindObjectOfType<TaskController>();
        }
    }
    public override void Interact()
    {
        taskController.CheckOffTask(taskNumber);
    }
}
