using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLaser : MonoBehaviour
{
    public GameObject firepoint;
    public LineRenderer Lr;
    public float maximumLength;
    public GameObject player;


    private void Update()
    {
        Lr.SetPosition(0, firepoint.transform.position);
        RaycastHit hit;

        if (Physics.Raycast (firepoint.transform.position, firepoint.transform.position, out hit, maximumLength))
        {
            if(hit.collider)
            {
                Lr.SetPosition(1, hit.point);
            }
        }
        else
        {
            Lr.SetPosition(1, player.transform.position);
        }
    }
}
