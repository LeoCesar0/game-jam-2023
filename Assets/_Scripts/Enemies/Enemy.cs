using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Enemy : BaseCharacter, IAttacker
{

    public GameObject attackTarget;
    private GameObject attackSpawn;
    private Animator animator;
    public GameObject hitBoxPrefab;

    public int getAttackDamage
    {
        get
        {
            return stats.attackDamage;
        }
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        stats = new BaseStats(100, 8);
        stats.attackSpeed = 1.5f;
        stats.speed = 2f;
        animator = GetComponent<Animator>();

        attackSpawn = GameObject.FindWithTag("AttackSpawn");
    }

    // Update is called once per frame
    void Update()
    {

        HandleAttack();
        if (status.isAttacking)
        {

            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }

    public override bool TakeDamage(int damage, GameObject attacker = null)
    {
        return base.TakeDamage(damage, attacker);
    }

    protected override void OnDie()
    {
        Destroy(gameObject);
    }

    private void HandleAttack()
    {
        if (attackTarget != null && status.isAttacking == false)
        {
            Vector2 directionToTarget = attackTarget.transform.position - transform.position;
            bool enemyIsToTheRight = directionToTarget.x > 0;
            float lookingAxis = 1;
            if (!enemyIsToTheRight)
            {
                lookingAxis = -1;
            }
            transform.localScale = new Vector2(lookingAxis, 1);
            status.isAttacking = true;
            StartCoroutine(Attack());

        }
    }

    public IEnumerator Attack()
    {

        status.isAttacking = true;
        // GameObject hitBoxGO = Instantiate(GamePrefabs.Instance.EnemyHitbox, attackSpawn.transform.position, Quaternion.identity);
        // EnemyHitbox hitbox = hitBoxGO.GetComponent<EnemyHitbox>();
        EnemyHitbox.Create(attackSpawn.transform.position, this);

        // if (hitbox)
        // {
        //     hitbox.SetAttackDamage(stats.attackDamage);
        // }
        // else
        // {
        //     Debug.Log("Enemy hitbox is null");
        // }

        // EnemyHitbox.Create(attackSpawn.transform.position, stats.attackDamage);

        yield return new WaitForSeconds(1f);
        status.isAttacking = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (attackTarget == other.gameObject)
        {
            attackTarget = null;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        Crystal crystal = other.gameObject.GetComponent<Crystal>();
        Turret turret = other.gameObject.GetComponent<Turret>();

        if (crystal != null)
        {
            attackTarget = other.gameObject;
            return;
        }

        // If the other object has a BaseStats component
        if (player != null)
        {
            if (attackTarget == null)
            {
                attackTarget = other.gameObject;
                return;
            }
        }
        if (turret != null)
        {
            if (attackTarget == null)
            {
                attackTarget = other.gameObject;
                return;
            }
        }
    }
}
