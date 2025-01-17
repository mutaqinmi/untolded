using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void OnActivate(string targetScene)
    {
        LoadingSceneManager.LoadScene(targetScene);
    }
}
