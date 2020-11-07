using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class ViewDetector : MonoBehaviour
{
    [SerializeField] private float viewDistance;
    [SerializeField] private float detectionAngle = 60;
    [SerializeField] private UnityEvent OnDetect, OnUndetect;
    private bool isLooking;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    private void Update()
    {
        var posDelta = Camera.main.transform.position - transform.position;
        var angle = Vector3.Angle(Camera.main.transform.forward, transform.position);
        if (angle < detectionAngle && (posDelta).magnitude < viewDistance)
        {
            if (!isLooking)
            {
                OnDetect?.Invoke();
                isLooking = true;
            }
        } else if (isLooking)
        {
            isLooking = false;
            OnUndetect?.Invoke();
        }
    }
}
