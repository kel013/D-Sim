using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    private int currPrefab;

    public void SetNext(int frames)
    {
        if ((currPrefab + 1) >= prefabs.Length)
            SetAfterFrames(0, frames);
        SetAfterFrames(currPrefab+1, frames);
    }

    private void Set(int index)
    {
        if (index >= prefabs.Length) return;
        if (index < 0) return;
        
        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i].SetActive(i == index);
            currPrefab = index;
        }
    }

    public void SetAfterFrames(int index, int frames)
    {
        StartCoroutine(SetAfterFramesCoroutine(index, frames));
    }

    private IEnumerator SetAfterFramesCoroutine(int index, int frames)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }
        Set(index);
    }
}
