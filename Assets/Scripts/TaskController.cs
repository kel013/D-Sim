﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public class TaskCheck
    {
        public Task task;
        public bool check;
    }
    [SerializeField]
    List<Task> taskList = new List<Task>();

    public List<TaskCheck> activeTasks = new List<TaskCheck>();
    [SerializeField]
    TaskDisplay display;


    private void Start()
    {
        RandomFillTasks(3);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckOffTask(0);
        }
    }

    public bool AllTasksDone()
    {
        for(int x = 0; x < activeTasks.Count; x++)
        {
            if(!activeTasks[x].check)
            {
                return false;
            }
        }
        return true;
    }

    public int ActiveTaskCount()
    {
        return activeTasks.Count;
    }

    public void RandomFillTasks(int x)
    {
        activeTasks.Clear();
        List<Task> r = taskList;
        for (int i = 0; i < x; i++)
        {
            if(r.Count == 0)
            {
                return;
            }
            int random = Random.Range(0, r.Count);
            TaskCheck task = new TaskCheck();
            task.task = r[random];
            activeTasks.Add(task);
            r.RemoveAt(random);
        }
        display.UpdateList();
    }

    public void UnfinishTask(int x)
    {
        activeTasks[x].task.done = false;
        display.UpdateList();
    }

    public void CheckOffTask(int x)
    {
        if(activeTasks[x].task.done)
        {
            activeTasks[x].check = true;
        }
        display.UpdateList();
    }

    public void Reset()
    {
        for(int x = 0; x < taskList.Count; x++)
        {
            taskList[x].done = false;
        }
    }
}
