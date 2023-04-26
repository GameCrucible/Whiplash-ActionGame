using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    //This code controls the cannon firing

    public GameObject Projectile; //Instatiates the Projectile
    public Vector3 raycastCollision = Vector3.zero; //Creates a raycast so the cannon can find enemies
    public bool isProjectile; //Keeps cannon from firing constantly
    public int fireTime; //determines firing time
    
    void Start()
    {//Sets cannon to be ready to fire
        isProjectile = false; }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 100))
        {
            if (isProjectile == false)
            {
                isProjectile = true; //Prevents multiple shots from happening at once
                GameObject projectile = Instantiate<GameObject>(Projectile); //Spawns cannonball
            }
        }
    }
}

  
