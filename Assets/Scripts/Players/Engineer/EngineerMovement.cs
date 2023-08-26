using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EngineerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    public bool lookingRight = true;
    private Animator animator;
    // private Vector3 facingRight;
    //  private Vector3 facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // facingRight = transform.localScale;
        // facingLeft = transform.localScale;
        // facingLeft.x = facingLeft.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // if(direction > 0)
        // {
        //     //olhando para direita
        //     transform.localScale = facingRight;
        // }
        // if(direction < 0)
        // {
        //     transform.localScale = facingLeft;
        //     //olhando para esquerda
        // }
       
       
        float hAxis = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hAxis = -1;
            lookingRight = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hAxis = 1;
            lookingRight = true;
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
