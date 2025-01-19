using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void OnClick(string targetScene)
    {
        LoadingSceneManager.LoadScene(targetScene);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
