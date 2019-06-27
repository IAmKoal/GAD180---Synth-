using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public int playerBulDamage = 10;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
    }
}
