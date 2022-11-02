using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float directionX;

    public float movementSpeed = 5;

    public float jumpForce = 15;

    public Transform[] groundCheck;

    public LayerMask groundMask;

    public float checkGroundDistance = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        for (int i = 0; i < groundCheck.Length; i++)
        {
            if (Physics2D.Raycast(groundCheck[i].position, -groundCheck[i].up, checkGroundDistance, groundMask))
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX * movementSpeed, rb.velocity.y);
    }


}
