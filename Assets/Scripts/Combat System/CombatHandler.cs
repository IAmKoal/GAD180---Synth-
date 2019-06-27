using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    //PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D enemyBulCol)
    {

        Debug.Log("Hit Bullet");
        if (enemyBulCol.gameObject.tag == "Enemy Bullet")
        {
            int enemyBulDamage = enemyBulCol.gameObject.GetComponent<EnemyBullet>().enemyDamage;
            player.playerCurrentHealth -= enemyBulDamage;

        }
    }
    */
    /*private void OnTriggerEnter2DPlayer(Collider2D playerBulCol)
    {
        Debug.Log("Enemy Hit");
        if(playerBulCol.gameObject.GetComponent<PlayerBullet>().tag == "Enemy")
        {
            int playerBulDamage = GetComponent<EnemyAttackPlaneStats>().enemyCurrentHealth;
            
        }
    }
    */
}
