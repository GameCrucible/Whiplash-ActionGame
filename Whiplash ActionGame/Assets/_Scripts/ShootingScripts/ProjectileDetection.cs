using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
