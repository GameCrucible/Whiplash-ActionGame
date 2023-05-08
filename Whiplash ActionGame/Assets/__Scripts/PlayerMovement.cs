using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 10; //how fast the player moves per second
    public Rigidbody rb;
    float horizontalInput; //left and right arrows or a and d keys
    public float horizontalMultiplier = 1.5f; // how quickly the horizontal movement from inputs is checked
    float verticalInput; //left and right arrows or a and d keys
    public float verticalMultiplier = 1.5f; // how quickly the horizontal movement from inputs is checked

    private void FixedUpdate(){
        if(!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        Vector3 verticalMove = transform.right * verticalInput * speed * Time.fixedDeltaTime * verticalMultiplier;
        //Vector3 m_Input = new Vector3(horizontalMove, 0, verticalMove);
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")*verticalMultiplier, 0);
        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + forwardMove + m_Input * Time.deltaTime * speed*horizontalMultiplier);
        //rb.MovePosition(rb.position + forwardMove + m_Input);
        //rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(transform.position.y<-5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart",2); //call restart after 2 seconds to have a delay 
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
