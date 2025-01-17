using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QuestPointer
{
    public class QuestPointer : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] RectTransform questSign;

        [Header("Quest")]
        public Quest[] Quests;

        private int index;

        private void Start()
        {
            index = 0;
        }

        private void Update()
        {
            if(!Quests[index].isCompleted)
            {
                SetQuestSign(Quests[index].questTarget);
            }
        }

        private void SetQuestSign(Transform target)
        {
            // Hitung posisi target dalam layar
            Vector3 targetScreenPoint = Camera.main.WorldToScreenPoint(target.position);

            // Periksa apakah target ada di depan kamera
            if (targetScreenPoint.z > 0)
            {
                float borderSize = 100f;

                // Jika target di luar layar, tampilkan pointer
                Vector2 cappedScreenPosition = new Vector2(
                    Mathf.Clamp(targetScreenPoint.x, borderSize, Screen.width - borderSize),
                    Mathf.Clamp(targetScreenPoint.y, borderSize, Screen.height - borderSize)
                );

                questSign.position = cappedScreenPosition;
                questSign.gameObject.SetActive(true);

                //Periksa apakah target berada di dalam area layar
                //bool isOnScreen = targetScreenPoint.x > borderSize &&
                //                  targetScreenPoint.x < Screen.width - borderSize &&
                //                  targetScreenPoint.y > borderSize &&
                //                  targetScreenPoint.y < Screen.height - borderSize;

                //if (isOnScreen)
                //{
                //    // Jika target berada dalam layar, sembunyikan pointer
                //    questSign.gameObject.SetActive(false);
                //}
                //else
                //{
                //    // Jika target di luar layar, tampilkan pointer
                //    Vector2 cappedScreenPosition = new Vector2(
                //        Mathf.Clamp(targetScreenPoint.x, borderSize, Screen.width - borderSize),
                //        Mathf.Clamp(targetScreenPoint.y, borderSize, Screen.height - borderSize)
                //    );

                //    questSign.position = cappedScreenPosition;
                //    questSign.gameObject.SetActive(true);
                //}
            }
            else
            {
                // Jika target di belakang kamera, sembunyikan pointer
                questSign.gameObject.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class Quest
    {
        public string questTitle;
        public Transform questTarget;
        public bool isCompleted;
    }
}