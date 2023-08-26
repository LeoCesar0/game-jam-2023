using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private int attackDamage;

    public void SetAttackDamage(int attackDamage)
    {
        this.attackDamage = attackDamage;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Detect collision with layer Players
        // Get the BaseStats component of the other object
        Player player = other.gameObject.GetComponent<Player>();
        // If the other object has a BaseStats component
        if (player != null)
        {
            Debug.Log("EnemyHitbox: hit");
            bool isDead = player.stats.TakeDamage(attackDamage);

            if (isDead)
            {
                player.OnDie();
            }
        }
    }
}