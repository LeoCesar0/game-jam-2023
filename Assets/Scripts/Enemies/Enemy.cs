using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{

    public int maxHp = 100;
    public int attackDamage = 10;
    public GameObject hitBoxPrefab;
    public GameObject attackTarget;
    private GameObject attackSpawn;
    private Animator animator;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stats.maxHp = maxHp;
        stats.attackDamage = attackDamage;
        stats.attackCooldown = 1.2f;
        stats.hp = maxHp;
        animator = GetComponent<Animator>();

        attackSpawn = GameObject.FindWithTag("AttackSpawn");
    }

    // Update is called once per frame
    void Update()
    {

        HandleAttack();
        if (isAttacking)
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

    public void OnDie()
    {
        Destroy(gameObject);
    }

    private void HandleAttack()
    {
        if (attackTarget != null && isAttacking == false)
        {
            Vector2 directionToTarget = attackTarget.transform.position - transform.position;
            bool enemyIsToTheRight = directionToTarget.x > 0;
            float lookingAxis = 1;
            if (!enemyIsToTheRight)
            {
                lookingAxis = -1;
            }
            transform.localScale = new Vector2(lookingAxis, 1);
            isAttacking = true;
            StartCoroutine(Attack());

        }
    }

    public IEnumerator Attack()
    {

        isAttacking = true;
        GameObject hitBox = Instantiate(hitBoxPrefab, attackSpawn.transform.position, Quaternion.identity);
        hitBox.GetComponent<EnemyHitbox>().SetAttackDamage(stats.attackDamage);

        yield return new WaitForSeconds(1f);
        isAttacking = false;

        // yield return new WaitForSeconds(stats.attackCooldown);
        // stats.isAttacking = false;
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
