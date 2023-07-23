using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausemenuGameObject;
    public static bool isPaused;


    private void Start()
    {
        PausemenuGameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseButton();
            }
        }
    }

    public void PauseButton()
    {
        PausemenuGameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        PausemenuGameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIITED");
    }
}
