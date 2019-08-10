using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncingGrenadeController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown;
    bool isCooldown;

    void Update()
    {
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
}
