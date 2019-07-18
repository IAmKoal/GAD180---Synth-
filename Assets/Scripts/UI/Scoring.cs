using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    // Change to how many digits you want
    public int scoreLength = 9;

    // this is the score
    public string newScore = "000000000";
    public int totalScore;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = newScore;
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        // score as a string
        string scoreString = totalScore.ToString();

        // get number of 0s needed
        int numZeros = scoreLength - scoreString.Length;

        newScore = "";
        for (int i = 0; i < numZeros; i++)
        {
            newScore += "0";
        }
        newScore += scoreString;
    }
}
