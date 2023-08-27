using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private GameObject attackSpawn;
    public GameObject bulletPrefab;
    private int attackDamage = 20;
    private float attackRange = 5f;
    private float attackSpeed = 1f;
    private float attackSpeedTimer = 0f;
    public GameObject target;
    CircleCollider2D rangeCircle;

    void Start()
    {
        rangeCircle = gameObject.AddComponent<CircleCollider2D>();
        rangeCircle.isTrigger = true;
        rangeCircle.radius = attackRange;

        // attackSpawn = GameObject.FindWithTag("AttackSpawn");
        attackSpawn = transform.Find("AttackSpawn").gameObject;

        // DrawAttackRange();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = null;
        }
    }

    void FixedUpdate()
    {

        if (target)
        {
            LookAtTarget();
            HandleAttack();
        }
    }

    void LookAtTarget()
    {

        Vector2 directionToTarget = target.transform.position - transform.position;
        bool enemyIsToTheRight = directionToTarget.x > 0;
        float lookingAxis = 1;
        if (!enemyIsToTheRight)
        {
            lookingAxis = -1;
        }
        transform.localScale = new Vector2(lookingAxis, 1);
    }

    void HandleAttack()
    {
        attackSpeedTimer += Time.deltaTime;
        if (attackSpeedTimer >= attackSpeed)
        {
            Attack();
            attackSpeedTimer = 0f;
        }
    }

    public void Attack()
    {
        Debug.Log("TURRET ATTACK");
        GameObject bulletGO = Instantiate(bulletPrefab, attackSpawn.transform.position, Quaternion.identity);
        TurretBullet bullet = bulletGO.GetComponent<TurretBullet>();
        bullet.SetAttackDamage(attackDamage);
        bullet.lookingRight = transform.localScale.x > 0;
    }
    // private void DrawAttackRange()
    // {
    //     Gizmos.DrawWireSphere(transform.position, attackRange);
    // }
}
