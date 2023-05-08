using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //check is collision is with player and coin
        
        if(other.gameObject.name != "Player")
        {
            return;
        }
        //Add to score
        GameManager.inst.IncrementScore();
        
        //Destroy the coin score
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }
}
