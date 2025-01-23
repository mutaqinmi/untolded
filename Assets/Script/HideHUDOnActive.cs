using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHUDOnActive : MonoBehaviour
{
    public GameObject hideableObject;
    public GameObject dialogueManager;
    private HideHUD isHUDHidden;
    private GameObject dialogueCanvasOnDialogueManager;

    void Start()
    {
        Transform uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
        isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();

        dialogueCanvasOnDialogueManager = dialogueManager.GetComponent<DialogueManager>().dialogueCanvas;
    }

    void Update()
    {
        if (!dialogueCanvasOnDialogueManager.activeInHierarchy)
        {
            if (!hideableObject.activeInHierarchy)
            {
                isHUDHidden.isHUDHidden = false;
            }
            else
            {
                isHUDHidden.isHUDHidden = true;
            }   
        }
    }
}
