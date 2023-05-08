using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position; // camera behind the player
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = player.position + offset; //offset lets you see the player
        //targetPos = player.position; //cannot see the player. it is in orthographic not perspective
        targetPos.x = 0; //keeps the middle of the frame centered. does not follow players movement. comment out to follow jumping around
        transform.position = targetPos;
        
    }
}
