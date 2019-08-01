using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStats : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 1.0f;


    public float boatMaxHealth;
    public float boatCurrentHealth;
    public SceneStuff sceneStuff;
    public Multiplier multiplier;
    private IEnumerator coroutine;


    public GameObject EnemyMissile;
    public Transform EnemyMissileSpawn;
    public float missileCooldownTime = 5;
    private float missileNextFireTime = 10;


    // Start is called before the first frame update
    void Start()
    {
        boatCurrentHealth = boatMaxHealth;

        if (Time.time == 10)
        {
            missileCooldownTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        BoatHealth();


        BoatMovement();

        if (Time.time > missileNextFireTime)
        {
            Instantiate(EnemyMissile, EnemyMissileSpawn.position, EnemyMissileSpawn.rotation);
            Debug.Log("Incoming Enemy Missile Detected!");
            missileNextFireTime = Time.time + missileCooldownTime;
        }

    }

    void BoatHealth()
    {
        if (boatCurrentHealth <= 0)
        {
            sceneStuff.enemiesKilled += 2;
            multiplier.KillEvent(75);
            Destroy(gameObject);
        }

        if (boatCurrentHealth <= 51 && boatCurrentHealth > 0)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    void BoatMovement()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * moveSpeed));

        if (transform.position != pointA.position && transform.position != pointB.position)
        {
            transform.position.y = transform.position.y 
        }
    }

    public void Damage(float damage)
    {
        coroutine = DamageIndication(0.1f);
        StartCoroutine(coroutine);
        boatCurrentHealth -= damage;
    }

    private IEnumerator DamageIndication(float time)
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
    }
}
