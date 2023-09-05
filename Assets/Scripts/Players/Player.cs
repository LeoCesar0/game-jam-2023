using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BaseStats stats = new BaseStats();
    public GameObject hitBoxPrefab;
    private GameObject attackSpawn;

    public bool isAttacking = false;

    public bool isMoving = false;

    public bool isRunning = false;

    public bool isDead = false;

    public bool isLookingRight = false;

    void Start()
    {
        attackSpawn = GameObject.FindWithTag("AttackSpawn");
        Debug.Log("attackSpawn -->" + attackSpawn);
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
        stats.isAttacking = true;
        GameObject hitBox = Instantiate(hitBoxPrefab, attackSpawn.transform.position, Quaternion.identity);
        hitBox.GetComponent<EnemyHitbox>().SetAttackDamage(stats.attackDamage);
    }
}
