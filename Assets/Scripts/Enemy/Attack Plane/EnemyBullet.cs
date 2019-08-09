using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int enemyDamage = 5;
    

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
