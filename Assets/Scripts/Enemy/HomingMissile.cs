using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public Transform playerTarget;
    public Animator animator;
    private Rigidbody2D rb;

    //[SerializeField]
    //GameCamera explosionEffect;

    [SerializeField]
    float thrust = 20f;

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
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.right * thrust;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        rb.velocity = new Vector2 (0,0);
        animator.SetBool("Hit", true);
        Destroy(gameObject);
    }
}
