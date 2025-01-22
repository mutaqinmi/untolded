using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI dialogueLabel;
        public TextMeshProUGUI dialogueText;
        public DialogueText[] dialogue;
        public float typeSpeed = 0.025f;

        private int index;

        void Start()
        {
            dialogueText.text = string.Empty;
            if(dialogueLabel != null)
            {
                dialogueLabel.text = string.Empty;
            }
            StartDialogue();
        }

        void Update()
        {
            if(dialogueLabel != null)
            {
                dialogueLabel.text = dialogue[index].name;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (dialogueText.text == dialogue[index].text)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogue[index].text;
                }
            }
        }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (char c in dialogue[index].text.ToCharArray())
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typeSpeed);
            }
        }

        void NextLine()
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                index = 0;
                dialogueText.text = string.Empty;
                gameObject.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class DialogueText
    {
        public string name;
        public string text;

        public DialogueText(string name, string text)
        {
            this.name = name;
            this.text = text;
        }
    }
}
