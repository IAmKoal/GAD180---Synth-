using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEngine : MonoBehaviour
{

    private Vector3 spawnLocations;
    public float spawnCD;
    public GameObject[] enemyPrefab;
    public float enemyAmt;

    // Start is called before the first frame update
    void Start()
    {
        spawnCD = 0;
        spawnLocations.z = -3;
    }

    // Update is called once per frame
    void Update()
    {
        spawnLocations.x = (Random.Range(5, 85));
        spawnLocations.y = (Random.Range(-2, 35));

        if (enemyAmt <= 9)
        {
            CreateSpawnPoint();
        }
    }

    void CreateSpawnPoint()
    {
        if(spawnCD <= 0)
        {
            GameObject newPortal = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnLocations, Quaternion.identity);
            spawnCD = 2.5f;
        }
        else
        {
            spawnCD -= Time.deltaTime;
        }
    }
}
