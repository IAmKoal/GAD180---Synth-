using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject EnemyShot;
    public Transform EnemyBulletSpawn;
    public float fireRate;

    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(EnemyShot, EnemyBulletSpawn.position, EnemyBulletSpawn.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
