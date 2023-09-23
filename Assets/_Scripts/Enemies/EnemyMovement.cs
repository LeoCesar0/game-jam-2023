using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;
    private Crystal crystal;
    private GameObject target;
    private float originalSpeed;
    public float Speed { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        crystal = FindObjectOfType<Crystal>();

        originalSpeed = enemy.stats.speed;
        Speed = enemy.stats.speed;
    }

    // Update is called once per frame
    void Update()
    {

        target = crystal.gameObject;

        if (enemy.attackTarget != null)
        {
            target = enemy.attackTarget;
        }

    }

    private void FixedUpdate()
    {
        if (!enemy.status.isAttacking && target != null)
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

        float velocityX = hAxis * Speed * 100 * Time.deltaTime;

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

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

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }
    IEnumerator ChangeSpeedCoroutine(float speed, float duration)
    {
        Speed = speed;
        yield return new WaitForSeconds(duration);
        Speed = originalSpeed;
    }
}
