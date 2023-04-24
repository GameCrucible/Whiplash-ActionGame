using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleStrafe : MonoBehaviour
{
    public Vector3 PlayerStrafeInput;
    public Vector3 velocity;

    [SerializeField] public Rigidbody rb;
    [SerializeField] public Transform playerStrafe;
    [SerializeField] public float speed = 12f;

    //[SerializeField] public Transform groundCheck;
    //[SerializeField] public LayerMask groundMask;
    //[SerializeField] public float groundDistance = 0.4f;
    //private bool isGrounded;

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerStrafeInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        //Keeps script velocity at 0 (DO NOT mess with this value)
        velocity.y = 0f;

        // Allows player to strafe while grappling
        StrafePlayer();
    }

    void StrafePlayer()
    {
        //Vector3 StrafeVector = transform.TransformDirection(PlayerStrafeInput) * speed;
        //rb.velocity = new Vector3(StrafeVector.x, rb.velocity.y, StrafeVector.z);

        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Clamp the velocity of the player when grappling so they don't go flying
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
        }

        // Resets the player's velocity if they are touching the ground
        //if (isGrounded && rb.velocity.y < 0)
        //{
        //        velocity.y = -2f;
        //}

        //Adds force to the player relative to where they are facing (the player can swing)
        rb.AddRelativeForce(PlayerStrafeInput * Time.deltaTime, ForceMode.Impulse);
    }
}
