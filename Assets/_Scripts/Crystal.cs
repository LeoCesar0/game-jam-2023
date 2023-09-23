using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDie();
        }
    }

    public void OnDie()
    {
        LevelManager.Instance.EndGame();
        Destroy(gameObject);
    }

}
