using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    protected Task linkedTask;
    public abstract void Interact();
    public UnityEvent onInteract;
}
