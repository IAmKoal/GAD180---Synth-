using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
   public Transform target;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        // if the player is facing right
        Vector3 targetPosition = target.TransformPoint(new Vector3(0.1f, 0.1f, -1f));
    
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
