using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseStats
{
    public int maxHp;
    public int hp;
    public int attackDamage;
    public float attackCooldown = 1f;

    public BaseStats()
    {
        hp = maxHp;
    }

}
