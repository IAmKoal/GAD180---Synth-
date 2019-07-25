﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMovement : MonoBehaviour
{
    [SerializeField]
    float thrust = 10f;

    private Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * thrust);
    }
}
