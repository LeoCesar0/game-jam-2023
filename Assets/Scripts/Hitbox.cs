using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox<T> : MonoBehaviour where T : BaseCharacter
{
    // private int attackDamage;
    protected float lifeTime = 0.1f;
    protected T owner;

    protected virtual void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(owner.stats.attackDamage);
        }
    }

    public static Hitbox<T> Create(Vector2 position, T owner)
    {
        Hitbox<T> hitbox = Instantiate(GamePrefabs.Instance.EnemyHitbox, position, Quaternion.identity).GetComponent<Hitbox<T>>();

        hitbox.owner = owner;

        return hitbox;
    }
}