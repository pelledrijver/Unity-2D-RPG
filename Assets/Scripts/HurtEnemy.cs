﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtEnemy : MonoBehaviour {

    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    private PlayerStats thePlayerStats;

    void Start () {
        thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	void Update () {



	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            currentDamage = thePlayerStats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }

}
