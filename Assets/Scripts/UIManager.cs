using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPText;
    public Text lvlText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePlayerStats;
    private static bool UIExists;

	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePlayerStats = GetComponent<PlayerStats>();

    }
	

	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        lvlText.text = "Lvl: " + thePlayerStats.currentLevel;
    }
}
