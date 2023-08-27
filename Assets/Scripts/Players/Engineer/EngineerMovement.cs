using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EngineerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    public bool lookingRight = true;
    private Animator animator;
    private Vector2 facingRight;
     private Vector2 facingLeft;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        
        float hAxis = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hAxis = -1;
            lookingRight = false;
            transform.localScale = facingLeft;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hAxis = 1;
            lookingRight = true;
            transform.localScale = facingRight;
        }
         if(hAxis != 0 )
        {
           //esta correndo
           animator.SetBool("Run", true);
        }
        else 
        {
            animator.SetBool("Run", false);
            //esta parado
        }

      

        float velocityX = hAxis * speed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}
