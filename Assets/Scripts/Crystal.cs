using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    public int hp = 200;


    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void EndGame(){
        Debug.Log("GAME OVER");
    }
}
