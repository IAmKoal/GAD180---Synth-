using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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

    public GameObject ricochetBul;
    public Transform ricoBulSpawn;
    private float nextGrenadeFire;
    public bool ricochetBulUnlocked = false;

    public float playerCurrentLevel;
    public PlayerLeveling currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        playerCurrentHealth = playerMaxHealth;
        playerCurrentLevel = currentLevel.playerCurrentLevel;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }

        if(playerCurrentLevel > 2)
        {
            ricochetBulUnlocked = true;
        }

        if(ricochetBulUnlocked == true)
        {

            if (Input.GetKeyDown(KeyCode.Z) && nextGrenadeFire <= 0)
            {
                Debug.Log("Grenade Fired!");
                Instantiate(ricochetBul, ricoBulSpawn.transform.position, ricoBulSpawn.rotation);
                nextGrenadeFire = 10;
            }
        }

        if (nextGrenadeFire > 1)
        {
            nextGrenadeFire -= Time.deltaTime;
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
