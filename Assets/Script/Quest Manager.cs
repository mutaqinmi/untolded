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

        // commented due pointer issues
        //private void Update()
        //{
        //    if(!Quests[questIndex].isCompleted)
        //    {
        //        SetQuestSign(Quests[questIndex].questTarget);
        //    }
        //}

        //private void SetQuestSign(Transform target)
        //{
        //    Vector3 targetScreenPoint = Camera.main.WorldToScreenPoint(target.position);

        //    if (targetScreenPoint.z > 0)
        //    {
        //        float borderSize = 20f;

        //        Vector2 cappedScreenPosition = new Vector2(
        //            Mathf.Clamp(targetScreenPoint.x, borderSize, Screen.width - borderSize),
        //            Mathf.Clamp(targetScreenPoint.y, borderSize, Screen.height - borderSize)
        //        );

        //        questSign.position = cappedScreenPosition;
        //        questSign.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        questSign.gameObject.SetActive(false);
        //    }
        //}
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