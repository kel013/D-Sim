using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel, controlsPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Controls()
    {
        if (controlsPanel.active)
            controlsPanel.SetActive(false);
        else
            controlsPanel.SetActive(true);
    }

    public void Credits()
    {
        if (creditsPanel.active)
            creditsPanel.SetActive(false);
        else
            creditsPanel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
