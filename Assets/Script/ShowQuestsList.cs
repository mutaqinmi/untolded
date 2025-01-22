using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShowQuestsList : MonoBehaviour
{
    private Transform questManager;
    void Start()
    {
        Transform manager = GameObject.Find("Manager").transform;
        questManager = manager.Find("QuestManager");
    }

    void Update()
    {
        QuestPointer.Quest[] quests = questManager.GetComponent<QuestPointer.QuestPointer>().Quests;
        string formattedText = "";

        for (int i = 0; i < quests.Length; i++)
        {
            formattedText += $"•<indent=40>{quests[i].questDescription}</indent>\n";
        }

        gameObject.GetComponent<TextMeshProUGUI>().text = formattedText;
    }
}
