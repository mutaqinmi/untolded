using MoreMountains.Tools;
using QuestManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject prompt;

    public void Awake()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if(activeScene == "MainMenu")
        {
            string lastScene = (string)MMSaveLoadManager.Load(typeof(string), "last_scene_save", "SaveData");

            Transform canvas = GameObject.Find("Canvas").transform;
            Transform buttonGroup = canvas.Find("Button");
            Transform continueButton = buttonGroup.Find("Continue Button");

            if (lastScene == null)
            {
                continueButton.gameObject.SetActive(false);
            }
            else
            {
                continueButton.gameObject.SetActive(true);
            }
        }
    }

    public void OnClickNewGame()
    {
        string lastScene = (string)MMSaveLoadManager.Load(typeof(string), "last_scene_save", "SaveData");

        if(lastScene != null)
        {
            if (prompt != null)
            {
                ShowPrompt();
            }
        }
        else
        {
            StartNewGame();
        }
    }

    public void SaveGame()
    {
        string lastScene = SceneManager.GetActiveScene().name;

        MMSaveLoadManager.Save(lastScene, "last_scene_save", "SaveData");
    }

    public void Continue()
    {
        string lastScene = (string)MMSaveLoadManager.Load(typeof(string), "last_scene_save", "SaveData");

        LoadingSceneManager.LoadScene(lastScene);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void InitializeNewGame()
    {
        MMSaveLoadManager.DeleteSave("quests_save", "SaveData");
        MMSaveLoadManager.DeleteSave("last_scene_save", "SaveData");

        List<Quest> quests = new();

        MMSaveLoadManager.Save(quests, "quests_save", "SaveData");
    }

    public void ShowPrompt()
    {
        prompt.SetActive(true);
    }

    public void StartNewGame()
    {
        InitializeNewGame();
        LoadingSceneManager.LoadScene("CutScene 1");
    }

    public void CancelNewGame()
    {
        prompt.SetActive(false);
    }
}