using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public int playerCurrentLevel = 1;
    public Scoring score;
    public int playerCurrentScore;
    

    private void Start()
    {
        playerCurrentScore = score.totalScore;
    }


    // Update is called once per frame
    void Update()
    {
        IncreasePlayerLevel();

    }

    private void IncreasePlayerLevel()
    {
        if (playerCurrentScore >= 1000)
        {
            Debug.Log("You Leved Up!");
            playerCurrentLevel = +1;
        }
        this.GetComponent<TMP_Text>().text = playerCurrentLevel.ToString();

        if (playerCurrentScore >= 2000)
        {
            Debug.Log("You Leved Up!");
            playerCurrentLevel = +1;
        }
        this.GetComponent<TMP_Text>().text = playerCurrentLevel.ToString();

        if (playerCurrentScore >= 4000)
        {
            Debug.Log("You Leved Up!");
            playerCurrentLevel = +1;
        }
        this.GetComponent<TMP_Text>().text = playerCurrentLevel.ToString();

        if (playerCurrentScore >= 6000)
        {
            Debug.Log("You Leved Up!");
            playerCurrentLevel = +1;
        }
        this.GetComponent<TMP_Text>().text = playerCurrentLevel.ToString();
    }
}
