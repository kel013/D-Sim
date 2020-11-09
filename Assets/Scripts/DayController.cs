using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DayController : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    TaskController taskController;
    [SerializeField] FirstPersonController playerController;
    [SerializeField] AudioSource alarmAudio;

    float fadeAmount = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        taskController = GetComponent<TaskController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDay()
    {
        taskController.ResetAll();
        StartCoroutine(FadeToNextDay());
    }

    IEnumerator FadeToNextDay()
    {
        for (float i = 0; i <= 2; i+=fadeAmount)
        {
            var tempColor = blackScreen.color;
            tempColor.a = i;
            blackScreen.color = tempColor;
            yield return new WaitForSeconds(fadeAmount);
        }

        playerController.enabled = false;
        yield return new WaitForSeconds(1.0f);
        alarmAudio.Play();
        yield return new WaitForSeconds(3.0f);

        for (float i = 2 ; i >= 0; i -= fadeAmount)
        {
            var tempColor = blackScreen.color;
            tempColor.a = i;
            blackScreen.color = tempColor;
            yield return new WaitForSeconds(fadeAmount);
        }

        playerController.enabled = true;
    }
}
