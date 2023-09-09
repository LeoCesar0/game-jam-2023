using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private int attackDamage;
    private float lifeTime = 0.5f;

    public void SetAttackDamage(int attackDamage)
    {
        this.attackDamage = attackDamage;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player player = other.gameObject.GetComponent<Player>();
        Crystal crystal = other.gameObject.GetComponent<Crystal>();
        Turret turret = other.gameObject.GetComponent<Turret>();

        if(crystal != null){
            crystal.TakeDamage(attackDamage);
        }
        // If the other object has a BaseStats component
        if (player != null)
        {
            bool isDead = player.TakeDamage(attackDamage);

            if (isDead)
            {
                player.OnDie();
            }
        }
        if (turret != null)
        {
            turret.TakeDamage(attackDamage);
        }
    }

}
