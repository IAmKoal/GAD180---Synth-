using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int playerMaxHealth = 100;
    public int playerCurrentHealth;
    public int playerShield;
    public SceneStuff sceneStuff;
    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        playerCurrentHealth = playerMaxHealth;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }

        Death();
    }
    private void OnTriggerEnter2D(Collider2D enemyBulCol)
    {
        if (enemyBulCol.gameObject.tag == "Enemy Bullet")
        {
            int enemyBulDamage = enemyBulCol.gameObject.GetComponent<EnemyBullet>().enemyDamage;
            playerCurrentHealth -= enemyBulDamage;
        }
    }

    public void Death()
    {
        if (playerCurrentHealth <= 0)
        {
            sceneStuff.playerAlive = false;
        }
    }
}
