using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public BaseStats stats = new BaseStats();
    public int maxHp = 100;
    public int attackDamage = 10;
    public GameObject hitBoxPrefab;
    public GameObject attackTarget;
    private GameObject attackSpawn;


    // Start is called before the first frame update
    void Start()
    {
        stats.maxHp = maxHp;
        stats.attackDamage = attackDamage;
        stats.attackCooldown = 1.2f;

        attackSpawn = GameObject.Find("AttackSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        HandleAttack();
    }

    public void OnDie()
    {
        Destroy(gameObject);
    }

    private void HandleAttack()
    {
        if (attackTarget != null && stats.isAttacking == false)
        {
            Vector2 directionToTarget = attackTarget.transform.position - transform.position;
            bool enemyIsToTheRight = directionToTarget.x > 0;
            float lookingAxis = 1;
            if (!enemyIsToTheRight)
            {
                lookingAxis = -1;
            }
            transform.localScale = new Vector2(lookingAxis, 1);
            stats.isAttacking = true;
            Attack();
        }
    }

    public void Attack()
    {
        stats.isAttacking = true;
        GameObject hitBox = Instantiate(hitBoxPrefab, attackSpawn.transform.position, Quaternion.identity);
        hitBox.GetComponent<EnemyHitbox>().SetAttackDamage(stats.attackDamage);

        // yield return new WaitForSeconds(stats.attackCooldown);
        // stats.isAttacking = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        // If the other object has a BaseStats component
        if (player != null)
        {
            if (attackTarget == other.gameObject)
            {
                attackTarget = null;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        // If the other object has a BaseStats component
        if (player != null)
        {
            if (attackTarget == null)
            {
                attackTarget = other.gameObject;
            }
        }
    }
}