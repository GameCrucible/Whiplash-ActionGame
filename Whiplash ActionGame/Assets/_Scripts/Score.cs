using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    //public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString("#,##0");
    }
}
