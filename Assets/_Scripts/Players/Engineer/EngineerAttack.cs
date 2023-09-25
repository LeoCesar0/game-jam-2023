using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EngineerAttack : MonoBehaviour
{

    private bool canSpawnTurret = true;
    private float turretSpawnCooldown = 6f;
    private GameObject turretPrefab;
    private Engineer engineer;
    private GameObject attackSpawn;

    void Start()
    {
        engineer = gameObject.GetComponent<Engineer>();
        turretPrefab = GamePrefabs.Instance.Turret;
        attackSpawn =  transform.Find("AttackSpawn").gameObject;
    }
    void Update()
    {

        if (Input.GetButtonDown("P1Fire1"))
        {
            BasicAttack();
        }


        HandleSpawnTurret();
    }

    private void BasicAttack(){
        PlayerHitbox hitbox = PlayerHitbox.Create(attackSpawn.transform.position, engineer);

        engineer.status.isAttacking = true;
    }

    private void HandleSpawnTurret()
    {
        if (Input.GetButtonDown("P1Fire2") && canSpawnTurret)
        {
            SpawnTurret();
            canSpawnTurret = false;
        }
    }

    public void SpawnTurret()
    {
        float xOffset = 0f;
        if (!engineer.status.isLookingRight)
        {
            xOffset *= -1;
        }
        Vector2 spawnPos = new Vector2(transform.position.x + xOffset, transform.position.y);
        Instantiate(turretPrefab, spawnPos, Quaternion.identity);
    }

    public void OnTurretDestroyed()
    {
        StartCoroutine(ResetSpawnTurret());
    }

    IEnumerator ResetSpawnTurret()
    {
        yield return new WaitForSeconds(turretSpawnCooldown);
        canSpawnTurret = true;
    }
}
