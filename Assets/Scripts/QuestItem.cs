using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int questNumber;
    private QuestManager theQM;
    public string itemName;

	void Start () {
        theQM = FindObjectOfType<QuestManager>();

	}
	

	void Update () {
		
	}

    //dit is het oppakken van een item
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player" && !theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
        {
            theQM.itemCollected = itemName;
            gameObject.SetActive(false);
        }
    }
}
