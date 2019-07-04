using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlaneStats : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public float enemyCurrentHealth;
    public SceneStuff sceneStuff;
    public SpawningEngine spawningEngine;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        spawningEngine = GameObject.Find("PortalManager").GetComponent<SpawningEngine>();
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        enemyCurrentHealth = enemyMaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            spawningEngine.enemyAmt -= 1;
            sceneStuff.enemiesKilled += 1;
            Destroy(gameObject);
            Debug.Log("Enemy Destroyed");
        }
        if(enemyCurrentHealth <= 51 && enemyCurrentHealth > 0)
        {
            particleSystem.Play();
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

    public void Damage(float damage)
    {
        enemyCurrentHealth -= damage;
    }
}
