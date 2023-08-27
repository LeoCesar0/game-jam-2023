using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackRange : MonoBehaviour
{
    // Start is called before the first frame update
    public Turret turret;
    void Start()
    {
        turret = GetComponentInParent<Turret>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        {
            Debug.Log("Detect Collision");
            if (turret.target == null)
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Detect Collision");

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
