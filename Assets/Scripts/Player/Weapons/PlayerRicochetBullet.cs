using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRicochetBullet : MonoBehaviour
{
    public float speed;
    public float timeAlive;
    public int playerBulDamage = 30;
    public float currentDegree = 45f;
    private float nextGrenadeFire;
    public GameObject ricochetBul;

    public float ricochetSpawnAmt;
    public bool spawnRicochet;
    private IEnumerator coroutine;

    public Collider2D previousEnemy;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        timeAlive = 10f;

        spawnRicochet = true;
    }

    private void Update()
    {
        if (timeAlive >= 0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }


        if (nextGrenadeFire > 0)
        {
            nextGrenadeFire -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {


        if (enemyCollider.gameObject.tag == "Enemy Bi Plane" && enemyCollider !=previousEnemy)
        {
            for (int x = 0; x < 4; x++)
            {
                Instantiate(ricochetBul, gameObject.transform.position, Quaternion.Euler(new Vector3(0, currentDegree, 0)));
                currentDegree += 90f;
            }
        }

        previousEnemy = enemyCollider;
    }
}
