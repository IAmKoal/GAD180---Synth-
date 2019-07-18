using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public int playerCurrentLevel = 1;
    public Scoring score;
    public int playerCurrentScore;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        IncreasePlayerLevel();
        playerCurrentScore = score.totalScore;
    }

    private void IncreasePlayerLevel()
    {
        if (playerCurrentScore >= 1000 && playerCurrentLevel < 2)
        {
            playerCurrentLevel += 1;
        }
        
        if (playerCurrentScore >= 2000 && playerCurrentLevel < 3)
        {
            playerCurrentLevel += 1;
        }

        if (playerCurrentScore >= 4000 && playerCurrentLevel < 4)
        {
            playerCurrentLevel += 1;
        }

        if (playerCurrentScore >= 6000 && playerCurrentLevel < 5)
        {
            playerCurrentLevel += 1;
        }
        text.text = "Level - " + playerCurrentLevel.ToString();
    }
}
