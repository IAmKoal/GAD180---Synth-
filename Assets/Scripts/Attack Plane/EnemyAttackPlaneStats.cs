using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlaneStats : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public int enemyCurrentHealth;
    public SceneStuff scene;
    public SpawningEngine spawningEngine;

    // Start is called before the first frame update
    void Start()
    {
        spawningEngine = GameObject.Find("PortalManager").GetComponent<SpawningEngine>();
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            spawningEngine.enemyAmt -= 1;
            Destroy(gameObject);
            Debug.Log("Enemy Destroyed");
        }
    }

    private void OnTriggerEnter2D(Collider2D playerBulCol)
    {

        
        if (playerBulCol.gameObject.tag == "Player Bullet")
        {
            int playerBulDamage = playerBulCol.gameObject.GetComponent<PlayerBullet>().playerBulDamage;
            enemyCurrentHealth -= playerBulDamage;
            Debug.Log("Enemy Hit By Player Bullet");
        }
    }
}
