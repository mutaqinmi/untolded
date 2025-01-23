using MoreMountains.CorgiEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Canvas")]
    public GameObject dialogueCanvas;
    public bool shouldTrigger;

    [Header("Event Listener")]
    public UnityEvent onActive;
    public UnityEvent onInActive;

    private bool isActive = false;

    private void Start()
    {
        dialogueCanvas.SetActive(!shouldTrigger);
    }

    private void Update()
    {
        if (dialogueCanvas.activeInHierarchy)
        {
            Transform uiCamera = GameObject.Find("UI Camera").transform;
            Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
            HideHUD isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();

            isHUDHidden.isHUDHidden = true;
        }

        if (dialogueCanvas.activeInHierarchy && !isActive)
        {
            onActive.Invoke();
            isActive = true;
        }
        else if (!dialogueCanvas.activeInHierarchy && isActive)
        {
            onInActive.Invoke();
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && shouldTrigger)
        {
            dialogueCanvas.SetActive(shouldTrigger);
        }
    }
}
