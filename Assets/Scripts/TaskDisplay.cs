using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskDisplay : MonoBehaviour
{
    [SerializeField]
    List<TMP_Text> checkList = new List<TMP_Text>();
    [SerializeField]
    TaskController taskController;

    public void UpdateList()
    {
       for(int x = 0; x < checkList.Count;x++)
        {
            if (x < taskController.ActiveTaskCount())
            {
                checkList[x].gameObject.SetActive(true);
                if(taskController.activeTasks[x].check)
                {
                    checkList[x].text = "<s>" + taskController.activeTasks[x].task.taskName + "</s>";
                }
                else
                {
                    checkList[x].text = taskController.activeTasks[x].task.taskName;
                }
            }
            else
            {
                checkList[x].gameObject.SetActive(false);
            }
        }
    }

}
