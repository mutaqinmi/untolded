using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePromptManager : MonoBehaviour
{
    public void OnActivate(GameObject prompt)
    {
        prompt.SetActive(true);
        LevelManager.Instance.FreezeCharacters();
    }
}
