using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isActive; // True if the game is running, false if the game is paused
    public GameObject pauseUI;
    
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(isActive)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        else if(!isActive && Input.GetKeyDown("return"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isActive = true;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isActive = false;
    }
}
