using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncingGrenadeController : MonoBehaviour
{
    public PlayerStats playerStats;

    public Image imageCooldown;
    public float cooldown;
    bool isCooldown;

    void Update()
    {
        //TESTING. Wanted to see if I could stop the animation from activating until you reach level 4 but it stops the animation all together.
        /*if (playerStats.ricochetBulUnlocked == true)*/
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isCooldown = true;
            }*

            if (isCooldown)
            {
                imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

                //This will reset the image after the cooldown has finished.
                if (imageCooldown.fillAmount >= 1)
                {
                    imageCooldown.fillAmount = 0;
                    isCooldown = false;
                }
            }
        }
    }
}
