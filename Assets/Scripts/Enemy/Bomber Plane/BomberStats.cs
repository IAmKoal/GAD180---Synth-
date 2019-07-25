﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberStats : MonoBehaviour
{

    public float bomberMaxHealth = 200;
    public float bomberCurrentHealth;
    public SceneStuff sceneStuff;
    public Multiplier multiplier;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        bomberCurrentHealth = bomberMaxHealth;
        sceneStuff = GameObject.Find("SceneManager").GetComponent<SceneStuff>();
        multiplier = GameObject.Find("Multiplier").GetComponent<Multiplier>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (bomberCurrentHealth <= 0)
        {
            sceneStuff.enemiesKilled += 1;
            multiplier.KillEvent(1000);
            Destroy(gameObject);
        }
        if (bomberCurrentHealth <= 51 && bomberCurrentHealth > 0)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }

    }

    public void Damage(float damage)
    {
        coroutine = DamageIndication(0.1f);
        StartCoroutine(coroutine);
        bomberCurrentHealth -= damage;
    }

    private IEnumerator DamageIndication(float time)
    {
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0);
    }

}
