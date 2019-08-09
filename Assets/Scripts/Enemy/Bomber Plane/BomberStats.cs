using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberStats : MonoBehaviour
{
    [SerializeField]
    float bombCoolDownTime = 5, nextBombDrop = 8;
    [SerializeField]
    GameObject bomb, bombSpawnPoint;

    public float bomberMaxHealth = 200;
    public float bomberCurrentHealth;
    public SceneStuff sceneStuff;
    public Multiplier multiplier;
    public BomberSpawning bomberPortal;
    private IEnumerator coroutine;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        bomberCurrentHealth = bomberMaxHealth;
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        multiplier = GameObject.Find("Multiplier").GetComponent<Multiplier>();
        bomberPortal = GameObject.Find("BomberPortalManager").GetComponent<BomberSpawning>();
        SetBombRate();
        bombSpawnPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bomberCurrentHealth <= 0 && isAlive)
        {
            isAlive = false;
            sceneStuff.enemiesKilled += 1;
            bomberPortal.bomberAmt -= 1;
            multiplier.KillEvent(1000);
            Destroy(gameObject);
        }
        if (bomberCurrentHealth <= 51 && bomberCurrentHealth > 0)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }

        SpawnBomb();
    }

    public void Damage(float damage)
    {
        coroutine = DamageIndication(0.1f);
        StartCoroutine(coroutine);
        bomberCurrentHealth -= damage;
    }

    private IEnumerator DamageIndication(float time)
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
    }

    private IEnumerator DeathAnim(float time)
    {
        //animation of plane dying
        gameObject.GetComponent<Rigidbody2D>().angularDrag *= 5;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void SetBombRate()
    {
        if (Time.time == 5)
        {
            bombCoolDownTime = 0;
        }
    }

    void SpawnBomb()
    {
        if (Time.time > nextBombDrop)
        {
            Instantiate(bomb, bombSpawnPoint.transform.position, bombSpawnPoint.transform.rotation);
            Debug.Log("Enemy Bombs Incoming!!");
            nextBombDrop = Time.time + bombCoolDownTime;
        }
    }
}
