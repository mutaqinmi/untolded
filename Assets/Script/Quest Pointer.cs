using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QuestPointer
{
    public class QuestPointer : MonoBehaviour
    {
        private RectTransform questSign;

        [Header("Quest")]
        public Quest[] Quests;

        public int questIndex;

        private void Start()
        {
            Transform uiCamera = GameObject.Find("UI Camera").transform;
            Transform hudCanvas = uiCamera.Find("HUD Canvas");
            Transform questPointer = hudCanvas.Find("QuestPointer");

            questSign = questPointer.GetComponent<RectTransform>();
            
            questIndex = 0;
        }

        private void Update()
        {
            if(!Quests[questIndex].isCompleted)
            {
                SetQuestSign(Quests[questIndex].questTarget);
            }
        }

        private void SetQuestSign(Transform target)
        {
            Vector3 targetScreenPoint = Camera.main.WorldToScreenPoint(target.position);

            if (targetScreenPoint.z > 0)
            {
                float borderSize = 20f;

                Vector2 cappedScreenPosition = new Vector2(
                    Mathf.Clamp(targetScreenPoint.x, borderSize, Screen.width - borderSize),
                    Mathf.Clamp(targetScreenPoint.y, borderSize, Screen.height - borderSize)
                );

                questSign.position = cappedScreenPosition;
                questSign.gameObject.SetActive(true);
            }
            else
            {
                questSign.gameObject.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class Quest
    {
        public string questTitle;
        public string questDescription;
        public Transform questTarget;
        public bool isCompleted;
    }
}