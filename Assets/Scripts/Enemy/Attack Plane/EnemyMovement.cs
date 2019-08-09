using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject EnemyShot;
    public Transform EnemyBulletSpawn;
    public float fireRate, timeToShoot;
    private float shotCount = 0;
    public GameObject EnemyMissile;
    public Transform EnemyMissileSpawn;
    public float missileCooldownTime = 5;
    private float missileNextFireTime = 10;

    public bool canShoot = true;


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
        if (canShoot)
        {
            ShootingBullets();
        }

        if(timeToShoot > 0 && !canShoot)
        {
            timeToShoot -= Time.deltaTime;
            if(timeToShoot <= 0)
            {
                timeToShoot = 0;
                canShoot = true;
            }
        }

        if ( Time.time > missileNextFireTime)
        {
            Instantiate(EnemyMissile, EnemyMissileSpawn.position, EnemyMissileSpawn.rotation);
            Debug.Log("Incoming Enemy Missile Detected!");
            missileNextFireTime = Time.time + missileCooldownTime;
        }

    }

    public void ShootingBullets()
    {
        canShoot = false;
        if (timeToShoot <= 0)
        {
            Instantiate(EnemyShot, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
            StartCoroutine(BulletDelay(0.1f));
            shotCount++;
            if (shotCount == 5)
            {
                timeToShoot = 2;
                shotCount = 0;
            }
        }
    }

    private IEnumerator BulletDelay(float time)
    {
        yield return new WaitForSeconds(time);
        ShootingBullets();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
