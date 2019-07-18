using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    float timeToKill = 0;
    int multiplier = 1;

    public Scoring scoring;
    public int multiLength = 2;
    public string currentText;


    private void Start()
    {
        currentText = "X01";
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToKill > 0)
        {
            timeToKill -= Time.deltaTime;
        }
        else
        {
            timeToKill = 0;
            multiplier = 1;
        }

        UpdatingMulti();

        this.GetComponent<TMP_Text>().text = currentText;
    }

    public void KillEvent(int score)
    {
        if (multiplier < 20)
        {
            multiplier += 1;
        }
        timeToKill = 5;
        scoring.UpdateScore(multiplier * score);
    }

    void UpdatingMulti()
    {
        int multiNum = multiplier.ToString().Length;
        int numZeros = multiLength - multiNum;
        currentText = "X";

        for (int i = 0; i < numZeros; i++)
        {
            currentText += "0";
        }
        currentText += multiplier.ToString();
    }
}
