using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    public float yOffset;
    void Start()
    {
        player = FindObjectOfType<Engineer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y + yOffset;

            transform.position = new Vector3(x, y, transform.position.z);
        }

    }
}
