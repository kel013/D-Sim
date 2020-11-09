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

    public void SetDefault()
    {
        for (int i = 0; i < otherObjects.Length; i++)
        {
            otherObjects[i].SetActive(false);
        }
        defaultObject?.SetActive(true);
    }

    public void SetRandom()
    {
        var rand = Random.Range(0, otherObjects.Length);
        Set(rand);
    }
    private void Set(int index)
    {
        if (index >= otherObjects.Length) return;
        if (index < 0) return;
        
        for (int i = 0; i < otherObjects.Length; i++)
        {
            otherObjects[i].SetActive(i == index);
        }
        defaultObject?.SetActive(false);
    }
}
