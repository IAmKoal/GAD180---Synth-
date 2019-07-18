using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerRasor : MonoBehaviour
{
    public LineRenderer laserRender;
    public Transform laserPoint;
    public LayerMask layerMask;
    PlayerStats playerCurrentLvl;
    private float playerLvl;
    // Start is called before the first frame update
    void Start()
    {
        laserRender.enabled = false;
        laserRender.useWorldSpace = true;

        playerCurrentLvl = GetComponent<PlayerStats>();
        playerLvl = playerCurrentLvl.playerCurrentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLvl >= 5)
        {
            if (Input.GetKey(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(laserPoint.position, transform.right, 20, layerMask);

                if (hit)
                {
                    laserRender.SetPosition(0, laserPoint.position);
                    laserRender.SetPosition(1, hit.point);
                }

                else
                {
                    laserRender.SetPosition(0, laserPoint.position);
                    laserRender.SetPosition(1, laserPoint.position + laserPoint.right * 20);
                }

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Enemy Bi Plane")
                    {
                        hit.collider.gameObject.GetComponent<EnemyAttackPlaneStats>().Damage(35 * Time.deltaTime);
                    }
                }

                laserRender.enabled = true;
            }

            else
            {
                laserRender.enabled = false;
            }
        }
    }
}
