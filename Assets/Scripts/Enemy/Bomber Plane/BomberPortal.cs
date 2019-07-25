using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberPortal : MonoBehaviour
{
    private float bomberSpawnAmounts = 3;
    public GameObject[] bomberSpawns;
    public BomberSpawning bomberSpawningEngine;
    public bool spawnBombers;
    private IEnumerator coroutine;
    public SceneStuff sceneStuff;

    // Start is called before the first frame update
    private void Start()
    {
        spawnBombers = true;
        bomberSpawningEngine = GameObject.Find("PortalManager").GetComponent<BomberSpawning>();
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        SpawnEnemyBombers();
        Debug.Log(bomberSpawns.Length);
    }

    void SpawnEnemyBombers()
    {
        if (bomberSpawnAmounts > 0 && spawnBombers == true)
        {
            coroutine = WaitSpawn(1.5f);
            StartCoroutine(coroutine);
            GameObject enemy = Instantiate(bomberSpawns[Random.Range(0, bomberSpawns.Length - 1)], gameObject.transform.position, Quaternion.identity);
            bomberSpawningEngine.bomberAmt += 1;
            sceneStuff.enemiesSpawnNum += 1;
            enemy.name = sceneStuff.IDCreator(enemy.name);
        }
        else if (bomberSpawnAmounts == 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitSpawn(float time)
    {
        spawnBombers = false;
        bomberSpawnAmounts -= 1;
        yield return new WaitForSeconds(time);
        spawnBombers = true;
        SpawnEnemyBombers();
    }
}
