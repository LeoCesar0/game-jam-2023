using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EngineerMovement : MonoBehaviour
{

    public float speed;
    public bool isLookingRight = true;

    private Rigidbody2D rb;
    private Animator animator;
    private float hAxis = 0;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("P1Horizontal");
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
            isLookingRight = false;
        }
        if (xLocalScale > 0)
        {
            isLookingRight = true;
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
        float velocityX = hAxis * speed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}
