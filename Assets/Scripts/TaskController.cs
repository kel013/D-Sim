using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField]
    List<Task> taskList = new List<Task>();

    List<Task> activeTasks = new List<Task>();

    public bool AllTasksDone()
    {
        for(int x = 0; x < activeTasks.Count; x++)
        {
            if(activeTasks[x].done == false)
            {
                return false;
            }
        }
        return true;
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
            activeTasks.Add(r[random]);
            r.RemoveAt(random);
        }
    }

    public void UnfinishTask(int x)
    {
        activeTasks[x].done = false;
    }

    public void Reset()
    {
        for(int x = 0; x < taskList.Count; x++)
        {
            taskList[x].done = false;
        }
    }
}
