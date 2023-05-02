using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision col) //If the projectile hits something its deleted
    {
        delete();
    }

    void Awake()
    {
        Invoke("delete",4); //If the projectile hits nothing after a few seconds it deletes itself
    }

    void delete()
    {
        Destroy(gameObject); //Destroys the Projectile
    }
}
