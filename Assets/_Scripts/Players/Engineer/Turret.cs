using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float attackRange = 20f;
    public GameObject target;
    public int level = 1;
    public int kills = 0;
    public int hp = 150;

    private AudioSource audioSource;
    public AudioClip attackSoundWeak;
    public AudioClip attackSoundStrong;

    private GameObject attackSpawn;
    private int attackDamage = 100;
    private float attackRate = 0.5f;
    private float attackSpeedTimer = 0f;

    public int AttackDamage { get; private set; }
    public float AttackRate { get; private set; }

    TurretAttackRange turretAttackRange;


    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = attackSoundWeak;
        turretAttackRange = GetComponentInChildren<TurretAttackRange>();
        attackSpawn = transform.Find("AttackSpawn").gameObject;
        animator = GetComponent<Animator>();
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

    private void LevelUp()
    {
        level++;
        level = Mathf.Clamp(level, 1, 3);

        if (level == 2)
        {
            attackDamage += 60;
            attackRate = 0.2f;
            attackRange += 8;
            hp = 200;
        }

        if (level == 3)
        {
            attackRange += 8;
            attackDamage += 60;
            attackRate = 0.5f;
            hp = 300;
            audioSource.clip = attackSoundStrong;
        }

        animator.SetInteger("Level", level);

        turretAttackRange.turretCollider.radius = attackRange;
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
        if (attackSpeedTimer >= attackRate)
        {
            Debug.Log("FIRE");
            Attack();
            attackSpeedTimer = 0f;
        }

        // Attack every attackSpeed seconds
        // if (Time.time > attackSpeedTimer)
        // {
        //     Attack();
        //     attackSpeedTimer = Time.time + attackSpeed;
        // }
    }

    public void AddKill(int count)
    {
        kills += count;
        if (level == 1 && kills >= 10)
        {
            LevelUp();
        }
        if (level == 2 && kills >= 20)
        {
            LevelUp();
        }
    }

    public void OnDie()
    {
        Destroy(gameObject);
    }

    public bool TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDie();
            return true;
        }
        return false;
    }

    public void Attack()
    {
        TurretBullet.Create(attackSpawn.transform.position, this);

        audioSource.PlayOneShot(audioSource.clip);
        if (level == 2)
        {
            audioSource.PlayDelayed(0.075f);
        }
    }
}
