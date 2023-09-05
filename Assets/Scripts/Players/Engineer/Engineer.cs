using System.Collections;
using UnityEngine;

public class Engineer : Player
{
    void Start()
    {
        stats.maxHp = 200;
        stats.hp = stats.maxHp;
        stats.attackDamage = 40;
    }

}
