using System.Collections;
using UnityEngine;

public class Engineer : Player
{
    protected override void Start()
    {
        base.Start();

        stats = new BaseStats(200, 40);
        stats.attackSpeed = 1.5f;
        stats.speed = 2f;
    }
}
