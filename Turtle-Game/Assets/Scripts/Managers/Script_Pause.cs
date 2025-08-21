using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Script_Pause : MonoBehaviour
{

    public GameObject pauseUI;
    public static bool isPaused = false;

    //This is to make a private var show up in inspector like a public var would, while keeping it private
    [SerializeField] private InputAction pauseAction;
    [SerializeField] private InputAction quitAction;

    private void OnEnable()
    {
        //Enable input actions
        pauseAction.Enable();
        quitAction.Enable();

        //we need to subscribe (+=) to the event to call toggle pause when pressed. Because we dont need any context we can add a cast to the context using ctx, then calling toggle pause from there using =>
        pauseAction.performed += ctx => togglePause();
        quitAction.performed += ctx => Quit();

        pauseUI.SetActive(false);
    }
    private void OnDisable()
    {
        //Unsubscribe on disable to prevent memory leakage
        pauseAction.performed -= ctx => togglePause();
        quitAction.performed -= ctx => Quit();
        //Disable to prevent unintended behavior
        pauseAction.Disable();
        quitAction.Disable();
    }

    private void OnDestroy()
    {
        //Unsubscribe on distroy to prevent memory leakage
        pauseAction.performed -= ctx => togglePause();
        quitAction.performed -= ctx => Quit();
        //Disable to prevent unintended behavior
        pauseAction.Disable();
        quitAction.Disable();
    }

    private void togglePause()
    {
        if(isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
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
        //This checks if the platform is the unity editor or not, if it is it will quit playmode, if not it will quit the application. Im not a fan of how the 
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

