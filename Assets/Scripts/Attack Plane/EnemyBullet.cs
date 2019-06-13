using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int enemyDamage = 5;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collision enemyBulCol)
    {
        if (enemyBulCol.gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerStats>().TakeDamage(enemyDamage);
        }
    }
}
