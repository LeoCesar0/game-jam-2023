using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseStats
{
    public int maxHp;
    public int hp;
    public int attackDamage;
    public float attackSpeed = 1f;
    public float speed = 2;
    public float physicalArmor = 0f;
    public float magicArmor = 0f;

    public BaseStats(int hp, int attack)
    {
        this.hp = hp;
        this.maxHp = hp;
        this.attackDamage = attack;
    }
}
