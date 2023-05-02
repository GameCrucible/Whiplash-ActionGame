using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseX;
    public float mouseY;

    public float mouseSensitivity = 400f;

    // A reference to the player model
    public Transform playerModel;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hides cursor and locks it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetMouseSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse movement as mouse input
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        // Restricts look rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Applies xRotation to x-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Allow the player to look around
        playerModel.Rotate(Vector3.up * mouseX);
    }

    
}
