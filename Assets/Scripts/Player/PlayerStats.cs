﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int playerMaxHealth = 100;
    public int playerCurrentHealth;
    public int playerShield;


    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
