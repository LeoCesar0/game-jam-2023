using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Enemy enemy;

    public float speed = 4.8f;

    private Crystal crystal;

    // Start is called before the first frame update
    void Start()
    {   
        enemy = gameObject.GetComponentInChildren<Enemy>();
        crystal = FindObjectOfType<Crystal>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.attackTarget != null){
            FollowTarget(enemy.attackTarget);
        }

        if(enemy.attackTarget == null && !enemy.stats.isAttacking){
            FollowCrystal();
        }
    }


    void FollowCrystal(){
        FollowTarget(crystal.gameObject);
    }

    void FollowTarget(GameObject gameObject){
        Vector2 directionToTarget = gameObject.transform.position - transform.position;
        transform.Translate(directionToTarget.normalized * speed * Time.deltaTime * 100);
        FaceGameObject(gameObject);
    }

    void FaceGameObject(GameObject gameObject){
        Vector2 directionToTarget = gameObject.transform.position - transform.position;
            bool enemyIsToTheRight = directionToTarget.x > 0;
            float lookingAxis = 1;
            if (!enemyIsToTheRight)
            {
                lookingAxis = -1;
            }
            transform.localScale = new Vector2(lookingAxis, 1);
    }
}
