using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    [SerializeField]
    string[] endOfDayDisplay;

    int counter = 0;

    [SerializeField]
    TMP_Text text;

    public void CountUp()
    {
        counter++;
        text.text = endOfDayDisplay[counter];
    }
}
