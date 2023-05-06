using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleCollider : MonoBehaviour
{
    public AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.tag == "Enemy")
        {
            audio.Play();
            Debug.Log("trigger2");
            Destroy(other.gameObject);
        }
    }
}
