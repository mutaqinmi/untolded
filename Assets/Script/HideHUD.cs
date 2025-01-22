using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHUD : MonoBehaviour
{
    [SerializeField] GameObject arrows;
    [SerializeField] GameObject buttons;
    public bool isHUDHidden;

    private void Update()
    {
        if (isHUDHidden)
        {
            buttons.SetActive(false);
            arrows.SetActive(false);
        }
        else
        {
            buttons.SetActive(true);
            arrows.SetActive(true);
        }
    }
}
