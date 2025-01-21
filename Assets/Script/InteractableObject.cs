using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] GameObject interactButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactButton.GetComponent<MMTouchButton>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.GetComponent<MMTouchButton>().enabled = false;
    }
}
