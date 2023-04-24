using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    Transform player;
    float distance;
    public float maxDistance;
    public Transform head;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= maxDistance)
        {
            head.LookAt(player);
        }
    }
}
