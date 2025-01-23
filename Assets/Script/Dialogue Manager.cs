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
    private HideHUD isHUDHidden;
    private Transform uiCamera;

    private void Start()
    {
        uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
        isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();

        dialogueCanvas.SetActive(!shouldTrigger);
    }

    private void Update()
    {
        if (dialogueCanvas.activeInHierarchy && !isActive)
        {
            onActive.Invoke();
            isActive = true;
            if (isActive) isHUDHidden.isHUDHidden = true;

            Character character = FindAnyObjectByType<Character>();
            LevelManager.Instance.FreezeCharacters();
            character.MovementState.ChangeState(CharacterStates.MovementStates.Idle);

        }
        else if (!dialogueCanvas.activeInHierarchy && isActive)
        {
            onInActive.Invoke();
            isActive = false;
            if(!isActive)
            {
                isHUDHidden.isHUDHidden = false;
                uiCamera.gameObject.GetComponent<InputManager>().SetHorizontalMovement(0f);
            }

            LevelManager.Instance.UnFreezeCharacters();
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
