using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats
{
    public int maxHp;
    public int hp;
    public int attackDamage;
    public bool isDead;
    public bool isAttacking = false;
    public float attackCooldown = 1f;

    public BaseStats(){
        hp = maxHp;
        isDead = false;
    }

    public bool TakeDamage(int amount)
    {
        Debug.Log("TOOK DAMAGE " + amount);
        hp -= amount;
        if (hp <= 0)
        {
            isDead = true;
            return true;
        }
        return false;
    }

}
