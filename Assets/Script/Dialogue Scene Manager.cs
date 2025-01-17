using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] dialogueBox;
    public string scene;

    private int index;

    private float timer;

    void Start()
    {
        index = 0;

        dialogueBox[index].SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            // check is dialogue box self inactive
            if (!dialogueBox[index].activeInHierarchy)
            {
                // set the next dialogue box to false
                dialogueBox[index].SetActive(false);

                if(index < dialogueBox.Length - 1)
                {
                    index++;
                    dialogueBox[index].SetActive(true);
                }
                else
                {
                    LoadNextScene(scene);
                }
            }

            timer = 0;
        }
    }

    void LoadNextScene(string scene)
    {
        LoadingSceneManager.LoadScene(scene);
    }
}
