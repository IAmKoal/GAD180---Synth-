using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public EnemyAttackPlaneStats enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy Bi Plane")
        {
            enemy = collision.gameObject.GetComponent<EnemyAttackPlaneStats>();
            enemy.Death();
        }
    }
}
