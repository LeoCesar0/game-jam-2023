using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrefabs : Singleton<GamePrefabs>
{

    [SerializeField] private GameObject _DamageText;
    [SerializeField] private GameObject _Turret;
    [SerializeField] private GameObject _TurretBullet;
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private GameObject _EnemyHitbox;
    [SerializeField] private GameObject _PlayerHitbox;
    [SerializeField] private GameObject _EnemySpawn;


    /* --------------------------------- getters -------------------------------- */

    public GameObject DamageText { get { return _DamageText; } }
    public GameObject Turret { get { return _Turret; } }
    public GameObject TurretBullet { get { return _TurretBullet; } }
    public GameObject Enemy { get { return _Enemy; } }
    public GameObject EnemyHitbox { get { return _EnemyHitbox; } }
    public GameObject PlayerHitbox { get { return _PlayerHitbox; } }
    public GameObject EnemySpawn { get { return _EnemySpawn; } }

}
