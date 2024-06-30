using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 20.0f;
    public float jumpHeight = 1.0f;
    //public float gravity = -9.81f;
    public float gravity = 20.0f;

    public float jumpSpeed = 8.0f;
    public float verticalSpeed = 0.0f;
    
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate();
        Move();
    }


    void Move()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpSpeed;
            }
        }

        // Calculate movement direction
        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized * speed;
        Vector3 jumpMovement = new Vector3(0.0f, verticalSpeed, 0.0f);
        

        controller.Move(movement * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        cameraTransform.Rotate(Vector3.left * mouseY);
        transform.Rotate(Vector3.up * mouseX);
    }
}
