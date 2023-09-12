using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private float maxLifeTime = 0.5f;
    private float ySpeed = 1f;
    private float xSpeed = 0.5f;

    private float lifeTimer;

    private TextMeshPro textMesh;



    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        Destroy(gameObject, maxLifeTime);
        lifeTimer = maxLifeTime;
    }

    public void Setup(string text)
    {
        textMesh.text = text;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (lifeTimer >= maxLifeTime / 2)
        {
            transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(xSpeed, ySpeed * -1, 0) * Time.deltaTime;
        }

        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;




        lifeTimer -= Time.deltaTime;
    }


    /* --------------------------------- STATIC --------------------------------- */

    public static DamageText Create(Vector2 position, int damage)
    {
        DamageText damageText = Instantiate(GamePrefabs.Instance.DamageText, position, Quaternion.identity).GetComponent<DamageText>();
        damageText.Setup(damage.ToString());
        return damageText;
    }
}
