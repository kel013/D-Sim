using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class ViewDetector : MonoBehaviour
{
    [SerializeField] private float viewDistance;
    [SerializeField] private Transform optionalLookObject;
    [SerializeField] private UnityEvent OnDetect, OnUndetect, OnEnterRadius, OnLeaveRadius;
    private float detectionAngle;
    private bool isLooking, isInRadius;
    private Camera _camera;
    private Vector3 _pos;

    private void OnDrawGizmosSelected()
    {
        var pos = optionalLookObject ? optionalLookObject.transform.position : transform.position;
        Gizmos.DrawWireSphere(pos, viewDistance);
    }

    private void Start()
    {
        _camera = Camera.main;
        _pos = optionalLookObject ? optionalLookObject.transform.position : transform.position;
        detectionAngle = _camera.fieldOfView - 10;
    }

    private void Update()
    {
        var posDelta = _camera.transform.position - _pos;
        var angle = Vector3.Angle(-posDelta, _camera.transform.forward);
        if ((posDelta).magnitude < viewDistance)
        {
            if (!isInRadius)
            {
                OnEnterRadius?.Invoke();
                isInRadius = true;
            }
            if (angle < detectionAngle)
            {
                if (!isLooking)
                {
                    OnDetect?.Invoke();
                    isLooking = true;
                }
            } else if (isLooking)
            {
                OnUndetect?.Invoke();
                isLooking = false;
            }
        } else if (isInRadius)
        {
            OnLeaveRadius?.Invoke();
            isInRadius = false;
        }
    }
}
