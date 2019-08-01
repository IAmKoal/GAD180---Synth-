using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMovement : MonoBehaviour
{
    [SerializeField]
    float thrust = 25f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        rb.velocity = transform.right * thrust;
    }
}
