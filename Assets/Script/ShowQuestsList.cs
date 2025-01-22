using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowQuestsList : MonoBehaviour
{
    private Transform questManager;
    private List<QuestManager.Quest> quests;

    void Start()
    {
        Transform manager = GameObject.Find("Manager").transform;
        questManager = manager.Find("QuestManager");
        quests = questManager.gameObject.GetComponent<QuestManager.QuestManager>().quests;
    }

    void Update()
    {
        string formattedText = "";

        for (int i = quests.Count - 1; i >= 0; i--)
        {
            formattedText += $"{(quests[i].isCompleted ? "<s>" : "")}•<indent=40>{quests[i].questDescription}</indent>{(quests[i].isCompleted ? "</s>" : "")}\n";
        }

        gameObject.GetComponent<TextMeshProUGUI>().text = formattedText;
    }
}
