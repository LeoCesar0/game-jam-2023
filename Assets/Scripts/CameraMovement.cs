using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject engineer;
    void Start()
    {
        engineer = FindObjectOfType<Engineer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = engineer.transform.position.x;
        float y = engineer.transform.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
