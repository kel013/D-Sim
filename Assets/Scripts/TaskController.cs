using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class TaskController : MonoBehaviour
{
    AudioSource audio;

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
        ResetAll();

        audio = GameObject.FindWithTag("Board").GetComponent<AudioSource>();
    }

    public void ResetAll()
    {
        Reset();
        RandomFillTasks(3);
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
        List<Task> r = new List<Task>();
        r.AddRange(taskList);

        for (int i = 0; i < x; i++)
        {
            if(r.Count == 0)
            {
                return;
            }
            int random = Random.Range(0, r.Count);
            TaskCheck task = new TaskCheck();
            task.task = r[random];
            task.check = false;
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
            if (!activeTasks[x].task.isChecked)
                audio.Play();
            activeTasks[x].task.isChecked = true;
        }
        display.UpdateList();
    }

    public void Reset()
    {
        for(int x = 0; x < taskList.Count; x++)
        {
            taskList[x].done = false;
            taskList[x].isChecked = false;
        }
    }
}
