using MoreMountains.Tools;
using QuestManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void OnClick(string targetScene)
    {
        InitializeNewGame();
        LoadingSceneManager.LoadScene(targetScene);
    }

    public void SkipIntro()
    {
        LoadingSceneManager.LoadScene("Scene 1");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void InitializeNewGame()
    {
        List<Quest> quests = new()
        {
            new("Berangkat Sekolah", "Pergi ke sekolah"),
        };

        MMSaveLoadManager.Save(quests, "untolded_saved_filedata", "SaveData");
    }
}