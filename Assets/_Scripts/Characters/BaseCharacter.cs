using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, IDamageable
{
    public BaseStats stats = new BaseStats(100, 10);
    public CharacterStatus status = new CharacterStatus();
    GameObject damageTextPrefab;
    SpriteRenderer spriteRenderer;
    List<CharacterType> types = new List<CharacterType>();
    

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageTextPrefab = GamePrefabs.Instance.DamageText;
    }

    public virtual bool TakeDamage(int damage, GameObject attacker = null)
    {
        stats.hp -= damage;

        if (damageTextPrefab != null)
        {
            float offset = spriteRenderer.bounds.size.y / 2;
            Vector2 position = new Vector2(transform.position.x, transform.position.y + offset);

            DamageText.Create(position, damage);

            // GameObject damageText = Instantiate(damageTextPrefab, position, Quaternion.identity);
            // damageText.GetComponent<DamageText>().Setup(damage.ToString());
        }

        Debug.Log("Took " + damage + " damage. HP: " + stats.hp + "/" + stats.maxHp);

        if (stats.hp <= 0)
        {
            OnDie();
            return true;
        }
        return false;
    }

    protected virtual void OnDie()
    {
        status.isDead = true;
        this.enabled = false;
        Destroy(gameObject);
    }

}
