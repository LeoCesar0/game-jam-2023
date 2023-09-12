using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EngineerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float hAxis = 0;
    private Engineer engineer;
    private float originalSpeed;
    private float runSpeedMultiplier = 1.8f;
    public float Speed { get; private set; }


    void Start()
    {
        engineer = gameObject.GetComponent<Engineer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        originalSpeed = engineer.stats.speed;
        Speed = engineer.stats.speed;
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("P1Horizontal");


        if (Input.GetButton("P1Run"))
        {
            engineer.status.isRunning = true;
        }
        else
        {
            engineer.status.isRunning = false;
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
            engineer.status.isLookingRight = false;
        }
        if (xLocalScale > 0)
        {
            engineer.status.isLookingRight = true;
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

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }
    IEnumerator ChangeSpeedCoroutine(float speed, float duration)
    {
        Speed = speed;
        yield return new WaitForSeconds(duration);
        Speed = originalSpeed;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float currentSpeed = Speed;
        if (engineer.status.isRunning)
        {
            Speed = currentSpeed * runSpeedMultiplier;
        }
        float velocityX = hAxis * Speed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}
