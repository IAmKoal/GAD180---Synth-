using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public bool bobbingUp = true;
    public float bobSpeed = 1.0f;
    Vector3 origPos;
    public float bobOffset = 0.2f;

    private void Start()
    {
        origPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bobbingUp)
        {
            // Move the object forward along its y axis 1 by bobSpeed.
            transform.Translate(Vector3.up * Time.deltaTime * bobSpeed);

        }
        else
        {
            // Move the object upward in world space 1 by bobSpeed.
            transform.Translate(Vector3.down * Time.deltaTime *bobSpeed);
        }

        float y = origPos.y - this.transform.position.y;
        if (y< 0.0f)
        {
            y = y * -1;
        }
        if (y >= bobOffset)
        {
            bobbingUp = !bobbingUp;
        }
    }

}
