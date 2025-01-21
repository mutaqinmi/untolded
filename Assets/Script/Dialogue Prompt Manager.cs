using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePromptManager : MonoBehaviour
{
    private GameObject[] HUD;

    public void OnActivate(GameObject prompt)
    {
        HideHUD();
        prompt.SetActive(true);
        LevelManager.Instance.FreezeCharacters();
    }

    public void HideHUD()
    {
        HUD = GameObject.FindGameObjectsWithTag("HUD");

        if (HUD != null)
        {
            foreach (var hud in HUD)
            {
                hud.SetActive(false);
            }
        }
    }

    public void OnExit()
    {
        Transform uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas");
        Transform buttons = hudCanvas.Find("Buttons");
        Transform arrows = hudCanvas.Find("Arrows");

        if(buttons != null || arrows != null)
        {
            buttons.gameObject.SetActive(true);
            arrows.gameObject.SetActive(true);
        }
    }
}
