using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private int attackDamage;
    private float knockbackForce = 100f;
    private float lifeTime = 0.5f;

    public void SetAttackDamage(int attackDamage)
    {
        this.attackDamage = attackDamage;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Detect collision with layer Players
        // Get the BaseStats component of the other object
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        // If the other object has a BaseStats component
        if (enemy != null)
        {
            Debug.Log("PlayerHitbox: hit");
            bool isDead = enemy.stats.TakeDamage(attackDamage);

            if (isDead)
            {
                enemy.OnDie();
            }
            else
            {
                // Create a knock back logic on enemy
                Rigidbody2D enemyRb = other.gameObject.GetComponent<Rigidbody2D>();
                Vector2 knockbackDirection = enemyRb.transform.position - transform.position;
                enemyRb.AddForce(knockbackDirection * knockbackForce);
            }
        }
    }
}
