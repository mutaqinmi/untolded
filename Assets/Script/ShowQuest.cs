using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuestManager;

public class ShowQuest : MonoBehaviour
{
    public bool isDescription;
    private List<QuestManager.Quest> quests;

    void Start()
    {
        Transform manager = GameObject.Find("Manager").transform;
        Transform questManager = manager.Find("QuestManager");

        quests = questManager.gameObject.GetComponent<QuestManager.QuestManager>().quests;
        quests.Reverse();
    }

    void Update()
    {
        if(quests != null || quests.Count > 0 && gameObject.activeInHierarchy)
        {
            int activeQuestIndex = 0; // dapatkan quest terbaru

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
}