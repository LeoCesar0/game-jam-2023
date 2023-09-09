using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    public int enemiesNumber = 5;
    public int hp = 200;

    void Start()
    {
        LevelManager.Instance.spawns.Add(this);
        // StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        enemiesNumber += + 3;
    }

    public void OnDestroy()
    {
        LevelManager.Instance.spawns.Remove(this);
        Destroy(gameObject);

    }

    public void TakeDamage(int damage)
    {

        hp -= damage;
        if (hp <= 0)
        {
            OnDestroy();
        }
    }

}
