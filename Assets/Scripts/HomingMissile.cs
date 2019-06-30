using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        //playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        Vector2 direction = (Vector2)playerTarget.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.forward).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.forward * thrust;

        rb.AddRelativeForce(Vector3.forward * thrust);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
