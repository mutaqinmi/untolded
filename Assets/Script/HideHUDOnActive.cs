using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHUDOnActive : MonoBehaviour
{
    private HideHUD isHUDHidden;

    void Start()
    {
        Transform uiCamera = GameObject.Find("UI Camera").transform;
        Transform hudCanvas = uiCamera.Find("HUD Canvas").transform;
        isHUDHidden = hudCanvas.gameObject.GetComponent<HideHUD>();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            isHUDHidden.isHUDHidden = true;
        }
        else
        {
            isHUDHidden.isHUDHidden = false;
        }
    }
}
