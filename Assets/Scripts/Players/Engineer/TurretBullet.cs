using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private float speed = 40f;
    private int attackDamage = 10;
    private Rigidbody2D rb;

    private float knockbackForce = 1f;

    private float lifeTime = 10f;
    public bool lookingRight = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocityX = speed * Time.deltaTime * 100;
        if(!lookingRight){
            velocityX = velocityX * -1;
        }
        rb.velocity = new Vector2(velocityX, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("TurretBullet: Enemy hit");
            bool isDead = enemy.stats.TakeDamage(attackDamage);

            if (isDead)
            {
                enemy.OnDie();
            }
            else
            {
                Debug.Log("KNOCKBACK");
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
