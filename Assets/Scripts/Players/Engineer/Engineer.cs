using System.Collections;
using UnityEngine;

public class Engineer : Player
{
    public virtual void Start()
    {
        base.Start();

        stats.maxHp = 200;
        stats.hp = stats.maxHp;
        stats.attackDamage = 40;
    }

}
