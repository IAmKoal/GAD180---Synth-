using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlaneStats : MonoBehaviour
{
    public int enemyMaxHealth = 100;
    public float enemyCurrentHealth;
    public SceneStuff sceneStuff;
    public SpawningEngine spawningEngine;
    public Multiplier multiplier;
    private IEnumerator coroutine;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        spawningEngine = GameObject.Find("PortalManager").GetComponent<SpawningEngine>();
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        multiplier = GameObject.Find("Multiplier").GetComponent<Multiplier>();
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrentHealth <= 0 && isAlive)
        {
            isAlive = false;
            spawningEngine.enemyAmt -= 1;
            sceneStuff.enemiesKilled += 1;
            Debug.Log(sceneStuff.enemiesKilled);
            multiplier.KillEvent(50);
            StartCoroutine(DeathAnim(1));
        }
        if(enemyCurrentHealth <= 51 && enemyCurrentHealth > 0)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    public void Damage(float damage)
    {
        coroutine = DamageIndication(0.1f);
        StartCoroutine(coroutine);
        enemyCurrentHealth -= damage;
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
}
