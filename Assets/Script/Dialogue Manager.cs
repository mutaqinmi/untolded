using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueCanvas;

    void Start()
    {
        Transform uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
        HideHUD isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();

        isHUDHidden.isHUDHidden = true;
        dialogueCanvas.SetActive(true);
    }
}
