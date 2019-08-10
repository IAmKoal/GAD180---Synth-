using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPhysics : MonoBehaviour
{
    public float forceThrust, maxVelocity = 8, rotationSpeed;
    public Rigidbody2D planeBody;
    public PlayerStats currentState;
    public SpriteRenderer thruster;
    // Start is called before the first frame update
    void Start()
    {
        forceThrust = 50;
        rotationSpeed = 10;
        planeBody.gravityScale = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.jetPlaneEvolved == false)
        {
            thruster.enabled = false;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                planeBody.gravityScale = 3;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                planeBody.angularDrag = 10;
            }
        }
        else
        {
            //JET Plane Stalled Behaviour (Slower Descent / Slower turn Speed) 
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                planeBody.gravityScale = 1.5f;
                thruster.enabled = false;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                planeBody.angularDrag = 15;
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentState.jetPlaneEvolved == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                planeBody.AddForce(transform.right * forceThrust);
                planeBody.gravityScale = 0.25f;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                planeBody.angularDrag = 20;
                planeBody.AddTorque(-rotationSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                planeBody.angularDrag = 20;
                planeBody.AddTorque(rotationSpeed);
            }
        }
        else
        {
            //Jet Plane Moving Behaviour(Slower Descent / Slower turn Speed / Super Fast)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                planeBody.AddForce(transform.right * forceThrust * 2);
                planeBody.gravityScale = 0.1f;
                thruster.enabled = true;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                planeBody.angularDrag = 20;
                planeBody.AddTorque(-rotationSpeed / 2);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                planeBody.angularDrag = 20;
                planeBody.AddTorque(rotationSpeed / 2);
            }
        }
    }
}
