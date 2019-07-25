using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSpawning : MonoBehaviour
{

    private Vector3 spawnLocations;
    public float spawnCoolDown;
    public GameObject[] bomberPrefab;
    public float bomberAmt;


    // Start is called before the first frame update
    void Start()
    {
        spawnCoolDown = 0;
        spawnLocations.z = -3;
    }

    // Update is called once per frame
    void Update()
    {
        spawnLocations.x = (Random.Range(5, 85));
        spawnLocations.y = (Random.Range(30,35));

        if (bomberAmt <= 9)
        {
            CreateSpawnPoint();
        }
    }

    void CreateSpawnPoint()
    {
        if (spawnCoolDown <= 0)
        {
            GameObject newPortal = Instantiate(bomberPrefab[Random.Range(0, bomberPrefab.Length)], spawnLocations, Quaternion.identity);
            spawnCoolDown = 2.5f;
        }
        else
        {
            spawnCoolDown -= Time.deltaTime;
        }
    }
}
