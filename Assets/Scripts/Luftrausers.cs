using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luftrausers : MonoBehaviour
{
    public float acceleration, handling, currentRotationX, currentRotationZ;
    public Rigidbody2D planeBody;

    private void Start()
    {
        currentRotationX = 0.0f;
        currentRotationZ = 0.0f;
    }

    private void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal") * handling;
        float movementVertical = Input.GetAxis("Vertical") * acceleration;

        planeBody.AddForce(transform.right * movementVertical);

        bool invertXRotation = false;
        bool invertZRotation = (currentRotationX < -180);

        if (invertXRotation)
        {
            currentRotationX = currentRotationX + -movementHorizontal % 360;
        }
        else
        {
            currentRotationX = currentRotationX + movementHorizontal % 360;
        }

        if (invertZRotation)
        {
            currentRotationZ = currentRotationZ + -movementHorizontal % 360;
        }
        else
        {
            currentRotationZ = currentRotationZ + movementHorizontal % 360;
        }

        Quaternion rotationX = Quaternion.AngleAxis(currentRotationX, Vector2.up);
        Quaternion rotationZ = Quaternion.AngleAxis(currentRotationZ, Vector2.left);

        Quaternion rotation = rotationX;
        transform.rotation = rotationZ;
    }
}
