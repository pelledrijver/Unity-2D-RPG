using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;
    public QuestManager theQM;
    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;


	void Start () {
		
	}
	

	void Update () {
        if (isItemQuest && theQM.itemCollected == targetItem)
        {
            theQM.itemCollected = null;
            EndQuest();
        }

        if (isEnemyQuest && theQM.enemyKilled == targetEnemy)
        {
            theQM.enemyKilled = null;
            enemyKillCount ++;
        }

        if(isEnemyQuest && enemyKillCount >= enemiesToKill)
        {
            EndQuest();
        }

	}

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }

}
