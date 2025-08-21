using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Script_Pause : MonoBehaviour
{

    public GameObject pauseUI;
    public static bool isPaused = false;

    InputAction restartAction;
    InputAction quitAction;


    // Start is called before the first frame update
    void Start()
    {
        restartAction = InputSystem.actions.FindAction("Restart");
        quitAction = InputSystem.actions.FindAction("Quit");
        Debug.Log("starting");
        Resume();
        //pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quitAction.IsPressed())
        Debug.Log("pause pressed");
        {
            if (isPaused)
            {
                Quit();
            }
            else
            {
                Pause();
            }
        }

        if (isPaused && restartAction.IsPressed())
        Debug.Log("resume pressed");
        {
            Resume();
        }
    }

    private void Pause()
    {
        Debug.Log("pausing");
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    private void Resume()
    {
        Debug.Log("resuming");
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Quit(){ 
        Debug.Log("quitting");
        Application.Quit();
    }
}

