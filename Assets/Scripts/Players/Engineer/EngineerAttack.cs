using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerAttack : MonoBehaviour
{

    private bool canSpawnTurret = true;
    private float turretSpawnCooldown = 6f;
    public GameObject turretPrefab;
    private Engineer engineer;

    void Start()
    {
        engineer = gameObject.GetComponent<Engineer>();
    }
    void Update()
    {

        if (Input.GetButtonDown("P1Fire1"))
        {
            // TODO
        }


        HandleSpawnTurret();
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
        if (!engineer.isLookingRight)
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
