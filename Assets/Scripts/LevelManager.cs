using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int currentLevel = 1;
    public float spawnCooldown = 20f;
    public float firstSpawnTime = 5f;
    private float spawnTimer;

    private AudioSource audioSource;

    public List<EnemySpawn> spawns = new List<EnemySpawn>();
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
        spawnTimer = firstSpawnTime;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        // DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/Game/game-over");
    }

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
            spawnTimer = spawnCooldown;
            SpawnEnemies();
        }
    }
    private void SpawnEnemies()
    {
        foreach (EnemySpawn spawn in spawns)
        {
            StartCoroutine(spawn.SpawnEnemies());
        }
    }

    public void EndGame()
    {
        audioSource.Play();
        StartCoroutine(ResetScene());
    }

    public IEnumerator ResetScene()
    {
        Debug.Log("START RESET SCENE");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
