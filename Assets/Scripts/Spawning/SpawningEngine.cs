using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEngine : MonoBehaviour
{

    private Vector3 spawnLocations;
    public float spawnCD;
    public GameObject[] enemyPrefab;
    public GameObject curPortal;

    // Start is called before the first frame update
    void Start()
    {
        spawnCD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnLocations.x = (Random.Range(5, 85));
        spawnLocations.y = (Random.Range(-2, 35));
        spawnLocations.z = -3;
        CreateSpawnPoint();
    }

    void CreateSpawnPoint()
    {
        if(spawnCD <= 0)
        {
            GameObject newPortal = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnLocations, Quaternion.identity);
            curPortal = newPortal;
            spawnCD = 2.5f;
            Debug.Log(curPortal.gameObject.transform.position);
        }
        else
        {
            spawnCD -= Time.deltaTime;
        }
    }
}
