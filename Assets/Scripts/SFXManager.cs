﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;
    private static bool sfxmanExists;

    void Start () {

        if (!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	
}
