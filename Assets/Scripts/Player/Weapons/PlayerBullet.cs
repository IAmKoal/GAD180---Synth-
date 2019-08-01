using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float timeAlive;
    public int playerBulDamage = 35;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        timeAlive = 2f;
    }

    private void Update()
    {
        if (timeAlive >= 0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        if (enemyCollider.gameObject.tag == "Enemy Bi Plane")
        {
            enemyCollider.GetComponent<EnemyAttackPlaneStats>().Damage(25);
            Destroy(gameObject);
        }

        if (enemyCollider.gameObject.tag == "Enemy Bomber")
        {
            enemyCollider.GetComponent<BomberStats>().Damage(20);
            Destroy(gameObject);
        }
    }
}
