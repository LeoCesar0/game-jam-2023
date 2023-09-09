using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    public GameObject hitBoxPrefab;
    private GameObject attackSpawn;


    protected override void Start()
    {
        base.Start();
        attackSpawn = GameObject.FindWithTag("AttackSpawn");
    }

    public override bool TakeDamage(int damage, GameObject attacker = null)
    {
        return base.TakeDamage(damage, attacker);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDie()
    {
        LevelManager.Instance.EndGame();
        Destroy(gameObject);
    }

    public void Attack()
    {
        isAttacking = true;
        GameObject hitBox = Instantiate(hitBoxPrefab, attackSpawn.transform.position, Quaternion.identity);
        hitBox.GetComponent<EnemyHitbox>().SetAttackDamage(stats.attackDamage);
    }

}
