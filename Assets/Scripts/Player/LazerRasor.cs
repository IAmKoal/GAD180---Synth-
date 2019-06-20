using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerRasor : MonoBehaviour
{
    public LineRenderer laserRender;
    public Transform laserPoint;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        laserRender.enabled = false;
        laserRender.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(laserPoint.position, transform.right, 20, layerMask);
        if (hit)
        {
            laserRender.SetPosition(0, laserPoint.position);
            laserRender.SetPosition(1, hit.point);
        }
        else
        {
            laserRender.SetPosition(0, laserPoint.position);
            laserRender.SetPosition(1, laserPoint.position + laserPoint.right * 20);
        }
        if (Input.GetKey(KeyCode.X))
        {
            laserRender.enabled = true;
        }
        else
        {
            laserRender.enabled = false;
        }
    }
}
