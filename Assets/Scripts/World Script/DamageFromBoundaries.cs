using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFromBoundaries : MonoBehaviour
{

    public float timeInOutside = 0, enemyOutside;
    public bool inBounds = false, enemyBounds = false;
    public PlayerStats playerStats;

    private void Update()
    {
       if(inBounds && timeInOutside == 0)
        {
            timeInOutside = 50;
        }

       if(timeInOutside > 0)
        {
            timeInOutside -= 1;
        }

       if(timeInOutside == 1)
        {
            playerStats.playerCurrentHealth -= 25;
        }

       if(!inBounds && timeInOutside > 0)
        {
            timeInOutside = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inBounds = false;
        }
    }
}
