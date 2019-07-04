using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDogFighter : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D enemyBody;
    public float angleChangingSpeed;
    public float movementSpeed;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - enemyBody.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        enemyBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        enemyBody.velocity = transform.right * movementSpeed;
    }
}
