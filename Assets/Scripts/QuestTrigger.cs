﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQM;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;

	void Start () {
        theQM = FindObjectOfType<QuestManager>();
	}
	

	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !theQM.questCompleted[questNumber])
        {
            if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.quests[questNumber].gameObject.SetActive(true);
                theQM.quests[questNumber].StartQuest();
            }

            if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.quests[questNumber].EndQuest();
            }
        }
    }

}
