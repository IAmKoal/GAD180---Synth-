using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public float forceThrust, maxVelocity = 6, rotationSpeed;
    public Rigidbody2D planeBody;
    public Quaternion currentRotation, fallingRotation;

    public GameObject Shot;
    public Transform BulletSpawn;
    public float fireRate;

    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        forceThrust = 50;
        rotationSpeed = 7;
        //fallingRotation = new Quaternion(0, 0, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //currentRotation = new Quaternion(planeBody.transform.rotation.x, planeBody.transform.rotation.y, planeBody.transform.rotation.z, 0) ;
        //if(Input.GetKeyUp(KeyCode.W))
        //{
        //    planeBody.gravityScale = 3;
        //    planeBody.MoveRotation(-90);
        //}

        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
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
            planeBody.AddTorque(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            planeBody.AddTorque(rotationSpeed);
        }
    }
}
