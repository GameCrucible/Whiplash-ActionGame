using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.tag == "Enemy")
        {
            Debug.Log("trigger2");
            Destroy(other.gameObject);
        }
    }
}
