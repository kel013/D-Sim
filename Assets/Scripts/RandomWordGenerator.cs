using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomWordGenerator : MonoBehaviour
{
    [SerializeField] private string[] words;
    [SerializeField] private int wordCount;
    [SerializeField] private TextMesh[] texts;

    private string[] selectedWords;
    private void Start()
    {
        selectedWords = new string[wordCount];
        
        for (int i = 0; i < wordCount; i++)
        {
            Array.Sort(words, (x, y) => Random.Range(-1, 2));
            Array.Sort(texts, (x, y) => Random.Range(-1, 2));
        }
        for (int i = 0; i < wordCount; i++)
        {
            var selected = texts[i];
            selected.text = words[i];
            selectedWords[i] = words[i];
        }
    }
}