using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;

    private PlayerStats thePlayerStats;

    void Start()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }


    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - thePlayerStats.currentDefence;
            if (currentDamage < 1)
            {
                currentDamage = 1;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }

}