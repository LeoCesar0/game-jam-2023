using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Engineer : Player
{
    public GameObject turretPrefab;
    private EngineerMovement movement;
    private bool canSpawnTurret = true;
    private float turretSpawnCooldown = 5f;

    void Start()
    {
        stats.maxHp = 200;
        stats.attackDamage = 40;

        movement = gameObject.GetComponent<EngineerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawnTurret();
    }

    private void HandleSpawnTurret()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) && canSpawnTurret)
        {
            Debug.Log("SPAWN TURRET");
            SpawnTurret();
            canSpawnTurret = false;
            StartCoroutine(ResetSpawnTurret());
        }
    }

    public void SpawnTurret()
    {
        float xOffset = 0f;
        if (!movement.lookingRight)
        {
            xOffset = xOffset * -1;
        }
        Vector2 spawnPos = new Vector2(transform.position.x + xOffset, transform.position.y);
        Instantiate(turretPrefab, spawnPos, Quaternion.identity);
    }

    IEnumerator ResetSpawnTurret()
    {
        yield return new WaitForSeconds(turretSpawnCooldown);
        canSpawnTurret = true;
    }

}
