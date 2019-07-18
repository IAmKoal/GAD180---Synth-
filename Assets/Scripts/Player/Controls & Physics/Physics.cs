using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public float forceThrust, maxVelocity = 8, rotationSpeed;
    public Rigidbody2D planeBody;

    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        forceThrust = 50;
        rotationSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            planeBody.gravityScale = 3;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            planeBody.angularDrag = 10;
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            planeBody.AddForce(transform.right * forceThrust);
            planeBody.gravityScale = 0.25f;
        }

        if(Input.GetKey(KeyCode.D))
        {
            planeBody.angularDrag = 20;
            planeBody.AddTorque(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            planeBody.angularDrag = 20;
            planeBody.AddTorque(rotationSpeed);
        }
    }
}
