using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EngineerMovement : MonoBehaviour
{

    public float speed;
    public float CurrentSpeed { get; private set; }

    private Rigidbody2D rb;
    private Animator animator;
    private float hAxis = 0;

    private Engineer engineer;

    void Start()
    {
        CurrentSpeed = speed;

        engineer = gameObject.GetComponent<Engineer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("P1Horizontal");


        if (Input.GetButton("P1Run"))
        {
            engineer.isRunning = true;
        }
        else
        {
            engineer.isRunning = false;
        }

        // Input.GetKey(KeyCode.LeftArrow)
        float xLocalScale = transform.localScale.x;
        if (hAxis < 0)
        {
            xLocalScale = Math.Abs(xLocalScale) * -1;
        }
        if (hAxis > 0)
        {
            xLocalScale = Math.Abs(xLocalScale);
        }

        transform.localScale = new Vector3(xLocalScale, transform.localScale.y, transform.localScale.z);

        if (xLocalScale < 0)
        {
            engineer.isLookingRight = false;
        }
        if (xLocalScale > 0)
        {
            engineer.isLookingRight = true;
        }
        if (hAxis != 0)
        {
            animator.SetBool("Run", true);
        }
        if (hAxis == 0)
        {
            animator.SetBool("Run", false);

        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentSpeed = speed;
        if (engineer.isRunning) CurrentSpeed = speed * 1.8f;
        float velocityX = hAxis * CurrentSpeed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}
