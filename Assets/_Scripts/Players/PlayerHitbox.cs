using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : Hitbox<Player>
{
    new public static PlayerHitbox Create(Vector2 position, Player owner)
    {
        PlayerHitbox hitbox = Instantiate(GamePrefabs.Instance.EnemyHitbox, position, Quaternion.identity).GetComponent<PlayerHitbox>();

        hitbox.owner = owner;

        return hitbox;
    }
}
