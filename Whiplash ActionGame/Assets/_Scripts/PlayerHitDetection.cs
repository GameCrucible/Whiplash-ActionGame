using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitDetection : MonoBehaviour
{
    //This script can probably be implemented into the Player code
    //I just made it seperate as a safety case
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Projectile") //Only activates when shot with a projectile
        {
            print("Hit with bullet");
            SceneManager.LoadScene("_Scene_Grapple"); //Resets player if hit
        }
    }
}
