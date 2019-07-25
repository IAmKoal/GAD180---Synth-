using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public Transform playerTarget;

    private Rigidbody2D rb;

    //[SerializeField]
    //GameCamera explosionEffect;

    [SerializeField]
    float thrust = 1;

    [SerializeField]
    float rotateSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {

        Vector2 direction = (Vector2)playerTarget.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        //rb.velocity = transform.up * thrust;

        rb.AddRelativeForce(Vector3.up * thrust);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
