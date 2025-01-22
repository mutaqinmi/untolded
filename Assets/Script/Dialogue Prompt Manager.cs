using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePromptManager : MonoBehaviour
{
    public void OnActivate(GameObject prompt)
    {
        prompt.SetActive(true);
        LevelManager.Instance.FreezeCharacters();
    }

    public void OnClosed(GameObject prompt)
    {
        prompt.SetActive(false);
        LevelManager.Instance.UnFreezeCharacters();
    }

    public void OnStateTrue(GameObject dialogueBox)
    {
        LoadingSceneManager.LoadScene("Scene 2");
    }

    //public void OnStateFalse(GameObject dialogueBox)
    //{
    //    dialogueBox.SetActive(true);
    //}
}
