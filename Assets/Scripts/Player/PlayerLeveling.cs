using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public int playerCurrentLevel = 1;
    public Scoring score;
    public int playerCurrentScore, toNextLevel;
    public TMP_Text text;

    private void Start()
    {
        toNextLevel = 691;
    }
    // Update is called once per frame
    void Update()
    {
        IncreasePlayerLevel();
        playerCurrentScore = score.totalScore;
    }

    private void IncreasePlayerLevel()
    {
        if (playerCurrentScore >= toNextLevel)
        {
            playerCurrentLevel += 1;
            toNextLevel = toNextLevel * 3 + 420;
        }

        text.text = "Level - " + playerCurrentLevel.ToString();
    }
}
