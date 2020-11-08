using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoAfterSeconds : MonoBehaviour
{
    [SerializeField] private float seconds;
    [SerializeField] private UnityEvent OnDone;

    public void Begin()
    {
        StartCoroutine(WaitCoroutine());
    }
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(seconds);
        OnDone?.Invoke();
    }
}