using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackRange : MonoBehaviour
{
    // Start is called before the first frame update
    public Turret turret { get; set; }
    public CircleCollider2D turretCollider;
    void Start()
    {
        turret = GetComponentInParent<Turret>();
        turretCollider = GetComponent<CircleCollider2D>();

        turretCollider.isTrigger = true;
        turretCollider.radius = turret.attackRange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        {
            if (turret.target == null)
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {

                    turret.target = other.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == turret.target)
        {
            turret.target = null;
        }
    }
}
