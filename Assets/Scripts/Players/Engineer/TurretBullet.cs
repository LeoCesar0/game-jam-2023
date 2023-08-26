using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private float speed = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = speed * Time.deltaTime * 100;
        transform.Translate(Vector2.right * velocityX);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Detect collision with layer Players
        // if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        // {
        // }
        // Get the BaseStats component of the other object
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("TurretBullet: Enemy hit");
            bool isDead = enemy.stats.TakeDamage(50);

            if (isDead)
            {
                enemy.OnDie();
            }
        }
    }


}
