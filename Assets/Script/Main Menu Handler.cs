using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void OnClickNewGame()
    {
        LoadingSceneManager.LoadScene("CutScene 1");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
