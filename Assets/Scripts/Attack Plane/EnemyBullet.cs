﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }
}
