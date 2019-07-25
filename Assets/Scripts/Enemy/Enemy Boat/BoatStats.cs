using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStats : MonoBehaviour
{

    public Transform startPoint;
    public Transform finishPoint;
    public float moveSpeed = 1.0f;
    private IEnumerable boatMovement;


    public float boatMaxHealth;
    public float boatCurrentHealth;
    public SceneStuff sceneStuff;
    public Multiplier multiplier;
    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        boatCurrentHealth = boatMaxHealth;
        StartCoroutine(boatMovement)();
    }

    // Update is called once per frame
    void Update()
    {
        if ( boatCurrentHealth <= 0)
        {
            sceneStuff.enemiesKilled += 2;
            multiplier.KillEvent(75);
            Destroy(gameObject);
        }
        if (boatCurrentHealth <= 51 && boatCurrentHealth > 0)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }

        BoatMovement();
    }

    IEnumerator BoatMovement()
    {

        for ( int i = 0, i ++)
        {
            if (transform.position == startPoint.position)
                WaitForSeconds
            {
                transform.position = Vector3.LerpUnclamped(startPoint.position, finishPoint.position, moveSpeed);
            }

        }

        if (transform.position == finishPoint.position)
        {
            transform.position = Vector3.LerpUnclamped(finishPoint.position, startPoint.position, moveSpeed);
        }
    }

    public void Damage(float damage)
    {
        coroutine = DamageIndication(0.1f);
        StartCoroutine(coroutine);
        boatCurrentHealth -= damage;
    }

    private IEnumerator DamageIndication(float time)
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
    }
}
