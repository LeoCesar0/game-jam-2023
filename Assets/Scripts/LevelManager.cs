using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // create a singleton
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("LevelManager");
                instance = gameObject.AddComponent<LevelManager>();
            }
            return instance;

        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public int currentLevel = 1;

    public float initialSpawnTimer = 10f;
    public float spawnTimer = 10f;
    public List<EnemySpawn> spawns = new List<EnemySpawn>();



    void Update()
    {

        CountDownSpawnTimer();
    }

    private void CountDownSpawnTimer()
    {
        // countDownSpawnRate
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = initialSpawnTimer;
            SpawnEnemies();
        }
    }
    private void SpawnEnemies()
    {
        foreach (EnemySpawn spawn in spawns)
        {
            spawn.SpawnEnemies();
        }
    }

    public void EndGame()
    {
        StartCoroutine("ResetScene");
    }

     public IEnumerator ResetScene()
    {
        Debug.Log("START RESET SCENE");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

}
