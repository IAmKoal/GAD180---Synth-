using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEngine : MonoBehaviour
{

    private Vector3 spawnLocations;
    public float spawnCD;
    public GameObject[] enemyPrefab;
    public float enemyAmt, currentLimit;
    public PlayerLeveling currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        spawnCD = 0;
        spawnLocations.z = -3;
        currentLevel = GameObject.Find("Player").GetComponentInChildren<PlayerLeveling>();
        currentLimit = 6;
    }

    // Update is called once per frame
    void Update()
    {
        spawnLocations.x = (Random.Range(5, 85));
        spawnLocations.y = (Random.Range(-2, 35));
        if (currentLevel.playerCurrentLevel > 4)
        {
            currentLimit = 2 + currentLevel.playerCurrentLevel * 2;
        }

        if (enemyAmt <= currentLimit)
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
