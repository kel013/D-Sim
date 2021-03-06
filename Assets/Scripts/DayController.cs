﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DayController : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    TaskController taskController;
    [SerializeField] FirstPersonController playerController;
    [SerializeField] AudioSource alarmAudio;
    [SerializeField] DayCounter count;
    [SerializeField] TMP_Text text;
    [SerializeField] DialogDisplay dialog;

    float fadeAmount = 0.03f;

    public List<Interactable> interactables = new List<Interactable>();
    public List<Grabbable> grabbables = new List<Grabbable>();


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
        count.CountUp();
        dialog.StopDialog();
        StartCoroutine(FadeToNextDay());
    }

    public void ResetDay()
    {
        taskController.ResetAll();
        foreach (Grabbable grabbable in grabbables)
        {
            grabbable.gameObject.SetActive(true);
            //Debug.Log(grabbable.gameObject.name);
            grabbable.ResetTransform();
        }
        foreach (Interactable interactable in interactables)
        {
            interactable.gameObject.SetActive(true);
            //Debug.Log(grabbable.gameObject.name);
            interactable.Reset();
        }
    }

    IEnumerator FadeToNextDay()
    {
        for (float i = 0; i <= 2; i+=fadeAmount)
        {
            var tempColor = blackScreen.color;
            tempColor.a = i;
            var textColor = text.color;
            textColor.a = i;
            blackScreen.color = tempColor;
            text.color = textColor;
            yield return new WaitForSeconds(fadeAmount);
        }

        ResetDay();
        playerController.enabled = false;
        yield return new WaitForSeconds(1.0f);
        alarmAudio.Play();
        yield return new WaitForSeconds(3.0f);

        for (float i = 2 ; i >= 0; i -= fadeAmount)
        {
            var tempColor = blackScreen.color;
            tempColor.a = i;
            var textColor = text.color;
            textColor.a = i;
            blackScreen.color = tempColor;
            text.color = textColor;
            yield return new WaitForSeconds(fadeAmount);
        }
        var tColor = blackScreen.color;
        tColor.a = 0;
        var texColor = text.color;
        texColor.a = 0;
        blackScreen.color = tColor;
        text.color = texColor;
        playerController.enabled = true;
    }
}
