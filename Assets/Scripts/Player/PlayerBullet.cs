using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float timeAlive;
    public int playerBulDamage = 10;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        timeAlive = 2f;
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
    }
}
