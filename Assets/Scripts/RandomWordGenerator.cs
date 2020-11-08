using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomWordGenerator : MonoBehaviour
{
    [SerializeField] private string[] words;
    [SerializeField] private int wordCount;
    [SerializeField] private Text[] texts;

    private string[] selectedWords;
    private void Start()
    {
        selectedWords = new string[wordCount];
        int[] nextArr;
        for (int i = 0; i < wordCount; i++)
        {
            var rand = Random.Range(0, words.Length);
            var selected = texts[rand];
            selected.text = words[rand];
            selectedWords[i] = words[rand];
            nextArr = new int[words.Length - 1];
            
        }
        
        
    }
}