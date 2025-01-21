using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuestPointer;

public class ShowQuest : MonoBehaviour
{
    public bool isDescription;
    private Transform questManager;
    void Start()
    {
        Transform manager = GameObject.Find("Manager").transform;
        questManager = manager.Find("QuestManager");
    }

    void Update()
    {
        QuestPointer.Quest[] quests = questManager.GetComponent<QuestPointer.QuestPointer>().Quests;
        int activeQuestIndex = questManager.GetComponent<QuestPointer.QuestPointer>().questIndex;

        if (isDescription)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = quests[activeQuestIndex].questDescription;
        } 
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = quests[activeQuestIndex].questTitle;
        }
    }
}
