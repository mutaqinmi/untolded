using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeNewQuest : MonoBehaviour
{
    public string questTitle;
    public string questDescription;

    public void NewQuest()
    {
        Transform manager = GameObject.Find("Manager").transform;
        Transform questManager = manager.Find("QuestManager");

        questManager.gameObject.GetComponent<QuestManager.QuestManager>().NewQuest(this.questTitle, this.questDescription);
    }
}
