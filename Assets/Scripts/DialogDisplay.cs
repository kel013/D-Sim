using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    float perCharacterPauseTime = 0.1f;
    int currentLine;
    bool talking;
    public void DisplayDialog(string[] line)
    {
        Debug.Log("talk");
        currentLine = 0;
        StartCoroutine(StartDialog(line));
    }
    IEnumerator StartDialog(string[] line)
    {
        talking = true;
        while (currentLine < line.Length)
        {
            text.text = line[currentLine];
            yield return new WaitForSeconds(1f + line[currentLine].Length * perCharacterPauseTime);
            currentLine++;
        }
        talking = false;
        text.text = "";
    }
}
