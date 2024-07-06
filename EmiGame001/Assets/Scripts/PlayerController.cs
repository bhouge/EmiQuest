using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedOfPlayer = 20.0f;
    public float jumpHeight = 2.0f;
    public float gravityAcceleration = -10.0f;

    private float jumpSpeed;
    private float verticalSpeed = 0.0f;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpSpeed = Mathf.Sqrt(2 * Mathf.Abs(gravityAcceleration) * jumpHeight);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (controller.isGrounded)
        {
            //verticalSpeed = 0.0f;

            //Debug.Log("Grounded!");
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("Jump!");
                verticalSpeed = jumpSpeed;
            }
        } else
        {
            verticalSpeed += gravityAcceleration * Time.deltaTime;
        }

        Vector3 movement = new Vector3 (horizontal, 0.0f, vertical).normalized * speedOfPlayer;
        Vector3 gravity = new Vector3(0.0f, verticalSpeed, 0.0f);

        controller.Move ((movement + gravity) * Time.deltaTime);
    }
}
