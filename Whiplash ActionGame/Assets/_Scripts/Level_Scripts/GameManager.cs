using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


[RequireComponent (typeof(TMP_Text))] //for score text
public class GameManager : MonoBehaviour
{
    public int score=0;
    public static GameManager inst;
    public Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        inst = this; //singleton
    }

    public void IncrementScore()
    {
        score+=100;
        //scoreText.text = "SCORE: ";
        //scoreText.text = score.ToString("#,##0");

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
