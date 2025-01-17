using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public void OnStateTrue(GameObject dialogue)
    {
        dialogue.SetActive(false);
        LoadingSceneManager.LoadScene("Scene 2");
    }

    public void OnStateFalse(GameObject dialogue)
    {
        dialogue.SetActive(true);
    }

    public void SetInactivePrompt(GameObject prompt)
    {
        prompt.SetActive(false);
        LevelManager.Instance.UnFreezeCharacters();
    }
}
