using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public float forceThrust, maxVelocity = 6, rotationSpeed;
    public Rigidbody2D planeBody;
    public float smoothTime, smooth, convertedTime = 200;
    public Vector3 initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        forceThrust = 50;
        rotationSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            planeBody.gravityScale = 3;
            smooth = Time.deltaTime * smoothTime * convertedTime;
            planeBody.AddTorque(planeBody.rotation * smooth);
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
