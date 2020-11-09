using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlitchEffect : MonoBehaviour
{
    private ViewDetector _viewDetector;
    private PrefabSwitcher _prefabSwitcher;

    [SerializeField] private float glitchDelay, glitchTime, prefabDelay, prefabFrames;
    [SerializeField] GameObject glitchObject;
    
    void Start()
    {
        _viewDetector = GetComponent<ViewDetector>();
        _viewDetector.OnDetect.AddListener(OnTrigger);
            
        _prefabSwitcher = GetComponent<PrefabSwitcher>();
    }

    void OnTrigger()
    {
        // glitch animation
        StartCoroutine(SetGlitchActive());
        
        // prefab switch
        StartCoroutine(FlashPrefab());
    }

    IEnumerator SetGlitchActive()
    {
        yield return new WaitForSeconds(glitchDelay);
        glitchObject.SetActive(true);
        yield return new WaitForSeconds(glitchTime);
        glitchObject.SetActive(false);
    }

    IEnumerator FlashPrefab()
    {
        yield return new WaitForSeconds(prefabDelay);
        _prefabSwitcher.SetDefault();
        for (int i = 0; i < prefabFrames; i++)
            yield return null;
        _prefabSwitcher.SetRandom();
    }
}
