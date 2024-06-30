using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedOfPlayer = 20.0f;

    private float speedOfGravity = -10.0f;
    private float jumpSpeed = 10.0f;
    private float verticalSpeed = 0.0f;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (controller.isGrounded)
        {
            //Debug.Log("Grounded!");
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("Jump!");
                verticalSpeed = jumpSpeed;
            }
        } else
        {
            verticalSpeed += speedOfGravity * Time.deltaTime;
        }

        Vector3 movement = new Vector3 (horizontal, 0.0f, vertical).normalized * speedOfPlayer;
        Vector3 gravity = new Vector3(0.0f, verticalSpeed, 0.0f);

        controller.Move ((movement + gravity) * Time.deltaTime);
    }
}
