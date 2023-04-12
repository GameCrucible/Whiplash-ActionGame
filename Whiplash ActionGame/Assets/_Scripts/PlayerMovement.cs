using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float x;
    float z;

    Vector3 move;
    Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resets the player's velocity if they are touching the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get inputs
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Apply inputs x and z to move vector
        move = transform.right * x + transform.forward * z;
        // Apply the move vector to the player
        controller.Move(move * speed * Time.deltaTime);

        // Allow the player the jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Calculate gravity 
        velocity.y += gravity * Time.deltaTime;

        // Apply gravity to the player
        controller.Move(velocity * Time.deltaTime);
    }
}
