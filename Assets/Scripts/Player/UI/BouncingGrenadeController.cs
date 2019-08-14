using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncingGrenadeController : MonoBehaviour
{
    public PlayerStats playerStats;
    public Image imageCooldown;
    public Image imageLocked;

    public float cooldown;
    bool isCooldown;
    bool isLocked;

    void Update()
    {
        //TESTING 
        //12-08-2019. Wanted to see if I could stop the animation from activating until you reach the respected level but it stops the animation all together. Didn't work.
        //14-08-2019. Did work on other UI elements, came back to this to try it again without changing anything and it worked.
        //14-08-2019. Need to change Ricohet Bullet to start its cooldown as soon as the grenade has left the player as trying to do the cooldown animation with what is currently there is very difficult. If this means the cooldown time is longer on the bomb it doesn't matter.

        if (playerStats.ricochetBulUnlocked == true)
        {
            Destroy(imageLocked);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isCooldown = true;
            }

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
        else
        if (playerStats.ricochetBulUnlocked == false)
        {
            if (isLocked)
            {
                imageLocked.fillAmount += 0;
            }
        }
    }
}
