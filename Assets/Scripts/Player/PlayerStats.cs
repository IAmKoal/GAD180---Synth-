using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    public int playerMaxHealth = 100, playerCurrentHealth, playerShield;
    public SceneStuff sceneStuff;
    public GameObject Shot, ricochetBul;
    public Transform BulletSpawn, ricoBulSpawn;
    public float fireRate, playerCurrentLevel, evolveCD;
    private float nextFire, nextGrenadeFire;
    public bool ricochetBulUnlocked = false, jetPlaneUnlocked = false, laserUnlocked = false, jetPlaneEvolved = false;
    public PlayerLeveling currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        playerCurrentHealth = playerMaxHealth;

        StartCoroutine(addHealth());
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentLevel = currentLevel.playerCurrentLevel;
        switch (playerCurrentLevel)
        {
            case 2:
                ricochetBulUnlocked = true;
                break;
            case 3:
                jetPlaneUnlocked = true;
                break;
            case 4:
                laserUnlocked = true;
                break;
            default:
                break;
        }
        Death();
        WeaponsCheck();
    }

    IEnumerator addHealth()
    {
        while (true)
            if (playerCurrentHealth < 100)
            {
                playerCurrentHealth += 2;
                yield return new WaitForSeconds(1);
            }
            else
                yield return null;
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

    public void WeaponsCheck()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }

        if (ricochetBulUnlocked == true)
        {
            if (Input.GetKeyDown(KeyCode.Z) && nextGrenadeFire <= 0)
            {
                Instantiate(ricochetBul, ricoBulSpawn.transform.position, ricoBulSpawn.rotation);
                nextGrenadeFire = 5;
            }
            else if(nextGrenadeFire > 0)
            {
                nextGrenadeFire -= Time.deltaTime;
            }
        }

        if (jetPlaneUnlocked == true)
        {
            //changes the players air craft into the jet can be switched
            if(Input.GetKeyDown(KeyCode.LeftShift) && evolveCD <= 0)
            {
                //this toggles the plane state
                jetPlaneEvolved = !jetPlaneEvolved;
                //Play swap animation
                //makes sure the player doesn't spam
                evolveCD = 5f;
            }
        }

        if(evolveCD > 0)
        {
            evolveCD -= Time.deltaTime;
        }
        else
        {
            evolveCD = 0;
        }
    }
}
