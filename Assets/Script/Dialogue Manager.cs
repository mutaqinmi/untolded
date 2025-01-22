using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueCanvas;
    public UnityEvent onActive;
    public UnityEvent onInActive;

    private void Start()
    {
        Transform uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
        HideHUD isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();

        isHUDHidden.isHUDHidden = true;
        dialogueCanvas.SetActive(true);
    }

    private void Update()
    {
        if (dialogueCanvas.activeInHierarchy)
        {
            onActive.Invoke();
        }
        else
        {
            onInActive.Invoke();
        }
    }
}
