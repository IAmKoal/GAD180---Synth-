using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public Vector3 cloudSpawn1;
    float coolDown;
    public GameObject[] clouds;
    GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cloudSpawn1 = GetSpawn(); 
        CreateClouds();
    }

    void CreateClouds()
    {
        if(coolDown <= 0)
        {
            spawn = Instantiate(clouds[Random.Range(0, clouds.Length)], cloudSpawn1, Quaternion.identity);
            spawn.GetComponent<Rigidbody2D>().AddForce(-transform.right * Random.Range(250, 600));
            coolDown = 1.5f;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
    }

    private Vector3 GetSpawn()
    {
        Vector3 spawn;
        spawn.x = 100;
        spawn.y = Random.Range(5, 33);
        spawn.z = -2;
        return (spawn);
    }
}
