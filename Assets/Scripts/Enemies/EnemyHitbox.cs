using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHitbox : Hitbox<Enemy>
{
    new public static EnemyHitbox Create(Vector2 position, Enemy owner)
    {
        EnemyHitbox hitbox = Instantiate(GamePrefabs.Instance.EnemyHitbox, position, Quaternion.identity).GetComponent<EnemyHitbox>();

        hitbox.owner = owner;

        return hitbox;
    }
}
