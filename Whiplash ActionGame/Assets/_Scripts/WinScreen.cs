using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    void Start()
    {
       Cursor.lockState = CursorLockMode.None;
    }
    public void PlayAgain() //play again button sets back to scene 1
    {
        SceneManager.LoadScene("Level");
    }

    public void ReturnMenu() { //return to menu returns to main menu
        SceneManager.LoadScene("MainMenu");
    }
}
