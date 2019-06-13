using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLaser : MonoBehaviour
{
    public Transform laser;

    private void Start()
    {
        Transform laser = gameObject.transform;
       
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            laser.localScale = new Vector3(10f, 0.15f);
        }
        else laser.localScale = new Vector3 (0f, 0f);
     
    }

    private void OnTriggerEnter(Collider laserCol)
    {
        if (laserCol.gameObject.tag == "Enemy")
        {
            Debug.Log("collision detected");
        }
    }

}
