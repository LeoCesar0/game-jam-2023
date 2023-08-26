using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    public bool lookingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
        float velocityX = hAxis * speed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}
