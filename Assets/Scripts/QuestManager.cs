﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogueManager theDM;
    public string itemCollected;
    public string enemyKilled;


    void Start () {
        questCompleted = new bool[quests.Length]; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowQuestText(string questText)
    {
        theDM.dialogueLines = new string[1];
        theDM.dialogueLines[0] = questText;
        theDM.currentLine = 0;
        theDM.ShowDialogue();
    }
 
}
