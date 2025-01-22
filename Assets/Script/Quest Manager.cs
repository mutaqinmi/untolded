using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Tools;

namespace QuestManager
{
    public class QuestManager : MonoBehaviour
    {
        public List<Quest> quests; // ini penting untuk list quest yang tersedia

        private void Awake()
        {
            quests = (List<Quest>)MMSaveLoadManager.Load(typeof(Quest), "untolded_saved_filedata", "SaveData");
        }

        public void Update()
        {
            Transform uiCamera = GameObject.Find("UI Camera").transform;
            Transform hudCanvas = uiCamera.Find("HUD Canvas");
            Transform hud = hudCanvas.Find("HUD");
            Transform questShow = hud.Find("Quest");

            if (quests == null || quests.Count == 0)
            {
                questShow.gameObject.SetActive(false);
            }
            else
            {
                questShow.gameObject.SetActive(true);
            }
        }

        public void NewQuest(string questTitle, string questDescription)
        {
            quests.Add(new Quest(questTitle, questDescription));

            MMSaveLoadManager.Save(quests, "untolded_saved_filedata", "SaveData");
        }

        public void MarkQuestAsDone()
        {
            quests.Reverse();
            quests[0].isCompleted = true;

            MMSaveLoadManager.Save(quests, "untolded_saved_filedata", "SaveData");
        }
    }

    [System.Serializable]
    public class Quest
    {
        public string questTitle;
        public string questDescription;
        public bool isCompleted = false;

        public Quest(string questTitle, string questDescription)
        {
            this.questTitle = questTitle;
            this.questDescription = questDescription;
        }
    }
}