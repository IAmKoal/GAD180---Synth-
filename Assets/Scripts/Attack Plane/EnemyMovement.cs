using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject EnemyShot;
    public Transform EnemyBulletSpawn;
    public float fireRate;
    private float nextFire;

    public GameObject EnemyMissile;
    public Transform EnemyMissileSpawn;
    public float missileCooldownTime = 5;
    private float missileNextFireTime = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (Time.time == 10)
        {
            missileCooldownTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(EnemyShot, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
        }

        if ( Time.time > missileNextFireTime)
        {
            Instantiate(EnemyMissile, EnemyMissileSpawn.position, EnemyMissileSpawn.rotation);
            missileNextFireTime = Time.time + missileCooldownTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
