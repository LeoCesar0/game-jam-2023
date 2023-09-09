using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private float speed = 30f;
    private int attackDamage = 10;
    private Rigidbody2D rb;

    private float knockbackForce = 1f;

    private float lifeTime = 10f;
    public bool lookingRight = true;

    private int level = 1;

    private Animator animator;

    public Turret turret;

    public void Setup()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        animator = GetComponent<Animator>();

        Destroy(gameObject, lifeTime);
    }

    public void SetLevel(int level)
    {
        this.level = level;
        animator.SetInteger("Level", level);
    }

    void FixedUpdate()
    {
        float currentSpeed = speed;
        if (level == 2) currentSpeed = speed * 1.5f;
        float velocityX = currentSpeed * Time.deltaTime * 100;
        if (!lookingRight)
        {
            velocityX *= -1;
        }
        rb.velocity = new Vector2(velocityX, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            bool isDead = enemy.TakeDamage(attackDamage);

            if (isDead)
            {
                if (turret != null)
                {
                    Debug.Log("Add Kill");
                    turret.AddKill(1);
                }
                enemy.OnDie();
            }
            else
            {
                // Rigidbody2D enemyRb = other.gameObject.GetComponent<Rigidbody2D>();
                // Vector2 knockbackDirection = enemyRb.transform.position - transform.position;
                // enemyRb.AddForce(knockbackDirection * knockbackForce);
            }
            Destroy(gameObject);
        }
    }

    public void SetAttackDamage(int attackDamage)
    {
        this.attackDamage = attackDamage;
    }


}
