using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStuff : MonoBehaviour
{
    public float enemiesKilled;
    public bool playerAlive;
    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesKilled >= 20)
        {
            SceneManager.LoadSceneAsync("End");
            Debug.Log("You Won");
        }

        if (!playerAlive)
        {
            SceneManager.LoadSceneAsync("End");
            Debug.Log("You Lost and you killed " + enemiesKilled);
        }
    }
}
