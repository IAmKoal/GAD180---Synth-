using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    public int playerMaxHealth = 100, playerCurrentHealth, playerPreviousHealth;
    public SceneStuff sceneStuff;
    public GameObject Shot, ricochetBul;
    public Transform BulletSpawn, ricoBulSpawn;
    public float fireRate, playerCurrentLevel, evolveCD;
    private float nextFire, nextGrenadeFire;
    public bool ricochetBulUnlocked = false, jetPlaneUnlocked = false, laserUnlocked = false, jetPlaneEvolved = false;
    public PlayerLeveling currentLevel;
    public IEnumerator coroutine;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        playerCurrentHealth = playerMaxHealth;
        playerAnimator = gameObject.GetComponent<Animator>();
        StartCoroutine(AddHealth());
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

    IEnumerator AddHealth()
    {
        while (true)
            if (playerCurrentHealth < 100)
            {
                playerCurrentHealth += 4;
                yield return new WaitForSeconds(1);
            }
            else
            {
                playerCurrentHealth = 100;
                yield return null;
            }
    }

    private void OnTriggerEnter2D(Collider2D enemyBulCol)
    {
        if (enemyBulCol.gameObject.tag == "Enemy Bullet")
        {
            int enemyBulDamage = enemyBulCol.gameObject.GetComponent<EnemyBullet>().enemyDamage;
            playerCurrentHealth -= enemyBulDamage;
            coroutine = DamageIndication(0.1f);
            StartCoroutine(coroutine);
        }
    }

    public void Death()
    {
        if (playerCurrentHealth <= 0)
        {
            sceneStuff.playerAlive = false;
        }
    }

    private IEnumerator DamageIndication(float time)
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
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
                Debug.Log("Grenade Launched");
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
                evolveCD = 2.5f;
                if (jetPlaneEvolved)
                {
                    playerAnimator.SetBool("jetPlaneEvolved", true);
                }
                else
                {
                    playerAnimator.SetBool("jetPlaneEvolved", false);
                }
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
