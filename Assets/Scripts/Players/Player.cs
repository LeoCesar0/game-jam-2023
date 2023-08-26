using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BaseStats stats = new BaseStats();
    public GameObject hitBoxPrefab;
    private GameObject attackSpawn;

    void Start()
    {
        attackSpawn = GameObject.Find("AttackSpawn");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnDie(){
        Destroy(gameObject);
    }

    public void Attack()
    {
        stats.isAttacking = true;
        GameObject hitBox = Instantiate(hitBoxPrefab, attackSpawn.transform.position, Quaternion.identity);
        hitBox.GetComponent<EnemyHitbox>().SetAttackDamage(stats.attackDamage);

        // yield return new WaitForSeconds(stats.attackCooldown);
        // stats.isAttacking = false;
    }
}
