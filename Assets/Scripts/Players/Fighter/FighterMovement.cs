using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 6.5f;
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

        if (Input.GetKey(KeyCode.A))
        {
            hAxis = -1;
            lookingRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hAxis = 1;
            lookingRight = true;
        }
        float velocityX = hAxis * speed * Time.deltaTime * 100;
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
}

