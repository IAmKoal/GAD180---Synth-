using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDogFighter : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D enemyBody;
    public float angleChangingSpeed;
    public float movementSpeed;
    public EnemyAttackPlaneStats enemy;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        enemy = gameObject.GetComponent<EnemyAttackPlaneStats>();
    }

    private void FixedUpdate()
    {
        if (enemy.isAlive == true)
        {
            Vector2 direction = (Vector2)target.position - enemyBody.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            enemyBody.angularVelocity = -angleChangingSpeed * rotateAmount;
            enemyBody.velocity = transform.right * movementSpeed;
        }
        else
        {
            enemyBody.mass = 200;
            enemyBody.gravityScale = 5;
            gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
            gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
        }
    }
}
