using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{

    public BaseStats stats = new BaseStats();
    GameObject damageTextPrefab;
    SpriteRenderer renderer;

    public bool isAttacking = false;

    public bool isMoving = false;

    public bool isRunning = false;

    public bool isDead = false;

    public bool isLookingRight = true;

    public bool isJumping = false;

    public bool isGrounded = true;

    protected virtual void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        damageTextPrefab = GamePrefabs.Instance.DamageText;
    }

    public virtual void HandleSetup()
    {
        stats.hp = 100;
        stats.maxHp = 100;
        stats.attackDamage = 10;
    }


    public virtual bool TakeDamage(int damage, GameObject attacker = null)
    {
        stats.hp -= damage;

        if (damageTextPrefab != null)
        {
            float offset = renderer.bounds.size.y / 2;
            Vector2 position = new Vector2(transform.position.x, transform.position.y + offset);
            
            DamageText.Create(position, damage);

            // GameObject damageText = Instantiate(damageTextPrefab, position, Quaternion.identity);
            // damageText.GetComponent<DamageText>().Setup(damage.ToString());
        }

        Debug.Log("Took " + damage + " damage. HP: " + stats.hp + "/" + stats.maxHp);

        if (stats.hp <= 0)
        {
            return true;
        }
        return false;
    }

}
