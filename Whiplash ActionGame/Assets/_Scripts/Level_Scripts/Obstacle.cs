using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement_Level playerMovement_level;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement_level = GameObject.FindObjectOfType<PlayerMovement_Level>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //kill player
            playerMovement_level.Die();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
