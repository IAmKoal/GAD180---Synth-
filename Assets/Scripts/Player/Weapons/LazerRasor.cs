using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerRasor : MonoBehaviour
{
    public LineRenderer laserRender;
    public Transform laserPoint;
    public LayerMask layerMask;
    public PlayerStats playerStats;
    public float laserLeft;
    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        laserLeft = 2.5f;
        laserRender.enabled = false;
        laserRender.useWorldSpace = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.laserUnlocked == true)
        {
            if (Input.GetKey(KeyCode.X) && laserLeft > 0 && canShoot == true)
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
                        hit.collider.gameObject.GetComponent<EnemyAttackPlaneStats>().Damage(1000 * Time.deltaTime);
                    }
                    if(hit.collider.gameObject.tag == "Enemy Bomber")
                    {
                        hit.collider.gameObject.GetComponent<BomberStats>().Damage(2500 * Time.deltaTime);
                    }
                }
                laserRender.enabled = true;
                laserLeft -= Time.deltaTime;
            }
            else
            {
                if (laserLeft < 2.5f)
                {
                    laserLeft += Time.deltaTime;
                    canShoot = false;
                }
                else
                {
                    laserLeft = 2.5f;
                    canShoot = true;
                }

                laserRender.enabled = false;
            }
        }
    }
}
