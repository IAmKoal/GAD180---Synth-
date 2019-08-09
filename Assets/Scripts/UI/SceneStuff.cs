using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStuff : MonoBehaviour
{
    public float enemiesKilled;
    public bool playerAlive;
    public int enemiesSpawnNum;
    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAlive)
        {
            SceneManager.LoadSceneAsync("End");
            Debug.Log("You were shot down and you killed " + enemiesKilled);
        }
    }

    public string IDCreator(string name)
    {
        string enemyID = enemiesSpawnNum.ToString();
        name = name + enemyID;
        return name;
    }
}
