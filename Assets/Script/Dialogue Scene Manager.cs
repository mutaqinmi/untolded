using MoreMountains.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSceneManager : MonoBehaviour
{
    [Header("List of dialogue box inside canvas")]
    public GameObject[] dialogueBox;

    [Header("Dialogue in-scene")]
    public GameObject dialogueCanvas;

    [Header("Jump to next scene")]
    public string scene;

    private int index;
    private float timer;

    void Start()
    {
        index = 0;

        if (dialogueCanvas != null)
        {
            if (dialogueCanvas.activeInHierarchy)
            {
                dialogueBox[index].SetActive(true);
            }
        }
        else
        {
            if (scene != string.Empty)
            {
                dialogueBox[index].SetActive(true);
            }
        }
    }

    void Update()
    {
        if(dialogueCanvas != null)
        {
            if (dialogueCanvas.activeInHierarchy)
            {
                if (scene == string.Empty)
                {
                    EndDialogue();
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= 5)
                    {
                        EndDialogue();

                        timer = 0;
                    }
                }
            }
        }
        else
        {
            if (scene != string.Empty)
            {
                if (scene == string.Empty)
                {
                    EndDialogue();
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= 5)
                    {
                        EndDialogue();

                        timer = 0;
                    }
                }
            }
        }
    }

    void EndDialogue()
    {
        // check is dialogue box self inactive
        if (!dialogueBox[index].activeInHierarchy)
        {
            // set the next dialogue box to false
            dialogueBox[index].SetActive(false);

            if (index < dialogueBox.Length - 1)
            {
                index++;
                dialogueBox[index].SetActive(true);
            }
            else
            {
                if (scene == string.Empty)
                {
                    dialogueCanvas.SetActive(false);
                }
                else
                {
                    LoadNextScene(scene);
                }
            }
        }
    }

    void LoadNextScene(string scene)
    {
        LoadingSceneManager.LoadScene(scene);
    }
}
