using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRicochetBullet : MonoBehaviour
{
    public float speed;
    public float timeAlive;
    public int playerBulDamage = 50;
    public int currentDegree;
    public GameObject ricochetBul;
    public int childNumber = 0;
    public string previousEnemy;
    public EnemyAttackPlaneStats enemy;

    private void Start()
    {
        if (childNumber < 1)
        {
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        timeAlive = 10f;
        if (childNumber > 3)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        currentDegree = (int)gameObject.transform.rotation.y;
        if (timeAlive >= 0)
        {
            timeAlive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        if (enemyCollider.gameObject.tag == "Enemy Bi Plane" && enemyCollider.gameObject.name != previousEnemy)
        {
            enemyCollider.GetComponent<EnemyAttackPlaneStats>().Damage(50);
            if (childNumber <= 3)
            {                
                for (int x = 0; x < 4; x++)
                {
                    childNumber++;
                    GameObject child = Instantiate(ricochetBul, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, currentDegree)));
                    child.GetComponent<PlayerRicochetBullet>().previousEnemy = enemyCollider.gameObject.name;
                    child.GetComponent<PlayerRicochetBullet>().childNumber = childNumber;
                    currentDegree += Random.Range(0, 90);
                }
                Destroy(gameObject);
            }
        }
        if (enemyCollider.gameObject.tag == "Enemy Bomber")
        {
            enemyCollider.GetComponent<BomberStats>().Damage(50);
            if (childNumber <= 3)
            {
                for (int x = 0; x < 4; x++)
                {
                    childNumber++;
                    GameObject child = Instantiate(ricochetBul, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, currentDegree)));
                    child.GetComponent<PlayerRicochetBullet>().childNumber = childNumber;
                    currentDegree += Random.Range(0, 90);
                }
                Destroy(gameObject);
            }
        }
    }
}
