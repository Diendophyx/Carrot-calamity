using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 15f;
    public float rotSpeed = 90;
    public float jumpspeed = 7.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public Transform art;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }



    public void Move(float inputH, float inputV, bool isJumping)
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, inputV);
            moveDirection = transform.TransformDirection(moveDirection);
            transform.Rotate(0, inputH * rotSpeed * Time.deltaTime, 0);
            moveDirection = moveDirection * speed;
            if (isJumping)
            {
                moveDirection.y = jumpspeed;
            }
        }
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        Vector3 lookD = transform.position + controller.velocity;
        lookD.y = transform.position.y;
        art.transform.LookAt(lookD);
    }
}
