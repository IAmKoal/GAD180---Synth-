using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy Bi Plane" || collision.tag == "Enemy Bomber")
        {
            enemy = collision.gameObject;
            StartCoroutine(EnemyDying(1));
        }
    }

    private IEnumerator EnemyDying(float time)
    {
        Debug.Log("PreDeath");
        //animation of dying
        yield return new WaitForSeconds(time);
        Destroy(enemy);
        Debug.Log("PostDeath");
    }
}
