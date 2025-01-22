using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkQuestAsDone : MonoBehaviour
{
    public void MarkAsDone()
    {
        Transform manager = GameObject.Find("Manager").transform;
        Transform questManager = manager.Find("QuestManager");

        questManager.gameObject.GetComponent<QuestManager.QuestManager>().MarkQuestAsDone();
    }
}
