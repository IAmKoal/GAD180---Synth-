using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBounds : MonoBehaviour
{
    public Transform planeTransform;

    private void Update()
    {
        if (planeTransform.position.x <= -5f)
        {
            planeTransform.SetPositionAndRotation(new Vector3(92, gameObject.transform.position.y, 0), transform.rotation);
        }
        else if (planeTransform.position.x >= 95)
        {
            planeTransform.SetPositionAndRotation(new Vector3(-3, gameObject.transform.position.y, 0), transform.rotation);
        }
    }
}
