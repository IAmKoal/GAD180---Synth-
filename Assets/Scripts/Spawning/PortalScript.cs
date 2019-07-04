using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private float spawnAmounts = 3;
    public GameObject[] enemySpawns;
    public SpawningEngine spawningEngine;
    public bool spawnSomething;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    private void Start()
    {
        spawnSomething = true;
        spawningEngine = GameObject.Find("PortalManager").GetComponent<SpawningEngine>();
        SpawnThemAll();
    }

    void SpawnThemAll()
    {
        if (spawnAmounts > 0 && spawnSomething == true)
        {
            coroutine = WaitSpawn(1.5f);
            StartCoroutine(coroutine);
            GameObject enemy = Instantiate(enemySpawns[Random.Range(0, enemySpawns.Length - 1)], gameObject.transform.position, Quaternion.identity);
            spawningEngine.enemyAmt.Add(enemy);
        }
        else if(spawnAmounts == 0)
        {
            Destroy(gameObject);
        }
    }
    
    private IEnumerator WaitSpawn(float time)
    {
            spawnSomething = false;
            spawnAmounts -= 1;
            yield return new WaitForSeconds(time);
            spawnSomething = true;
            SpawnThemAll();
    }
}
