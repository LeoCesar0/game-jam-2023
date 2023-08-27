using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Enemy enemy;

    private Rigidbody2D rb;

    public float speed = 4.8f;

    private Crystal crystal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        crystal = FindObjectOfType<Crystal>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject target = crystal.gameObject;

        if (enemy.attackTarget != null)
        {
            target = enemy.attackTarget;
        }

        if (!enemy.stats.isAttacking)
        {
            FollowTarget(target);
        }
    }

    void FollowTarget(GameObject gameObject)
    {
        Vector2 directionToTarget = gameObject.transform.position - transform.position;
        float hAxis = 1;
        if (directionToTarget.x < 0)
        {
            hAxis = -1;
        }

        float velocityX = hAxis * speed * 100 * Time.deltaTime;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        // Vector2 translate = directionToTarget.normalized * speed * Time.deltaTime * 100;
        // Debug.Log("translate: " + translate);
        // transform.Translate(translate);
        FaceGameObject(gameObject);
    }

    void FaceGameObject(GameObject gameObject)
    {
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
