using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public float maxVelocity = 3;

    public float rotationSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);

        Rotate(transform, xAxis * -rotationSpeed);
    }

    #region Maneuvering API

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(playerBody.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(playerBody.velocity.y, -maxVelocity, maxVelocity);

        playerBody.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount * 10f;

        playerBody.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    #endregion
}
