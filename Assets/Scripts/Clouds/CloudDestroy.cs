using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
