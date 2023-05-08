using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Score scoreUI;
    public void PlayButton()
    {
        SceneManager.LoadScene("Level");
        scoreUI.score = 0;
        
    }
}
