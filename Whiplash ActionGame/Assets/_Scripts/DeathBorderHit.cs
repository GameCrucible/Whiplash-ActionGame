using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBorderHit : MonoBehaviour
{
    public Transform player;
    public Score scoreUI;

    void Update()
    {
        if (player.position.y < -30f)
        {
            SceneManager.LoadScene("Level");
            scoreUI.score = 0;
        }
    }
}
