using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PrefabSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject defaultObject;
    [SerializeField] private GameObject[] otherObjects;
    private int currPrefab;

    public void SetNextAfterFrames(int frames)
    {
        if ((currPrefab + 1) >= otherObjects.Length)
            SetAfterFrames(0, frames);
        SetAfterFrames(currPrefab+1, frames);
    }

    public void SetDefaultAfterFrames()
    {
        // StartCoroutine(SetDefaultAfterFramesCoroutine(frames));
        for (int i = 0; i < otherObjects.Length; i++)
        {
            otherObjects[i].SetActive(false);
        }
        defaultObject.SetActive(true);
    }

    public void SetRandomAfterFrames(int frames)
    {
        var rand = Random.Range(0, otherObjects.Length);
        SetAfterFrames(rand, frames);
    }
    private void Set(int index)
    {
        if (index >= otherObjects.Length) return;
        if (index < 0) return;
        
        for (int i = 0; i < otherObjects.Length; i++)
        {
            otherObjects[i].SetActive(i == index);
            currPrefab = index;
        }
        defaultObject.SetActive(false);
    }

    public void SetAfterFrames(int index, int frames)
    {
        StopAllCoroutines();
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

    private IEnumerator SetDefaultAfterFramesCoroutine(int frames)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }
        for (int i = 0; i < otherObjects.Length; i++)
        {
            otherObjects[i].SetActive(false);
        }
        defaultObject.SetActive(true);
    }
}
