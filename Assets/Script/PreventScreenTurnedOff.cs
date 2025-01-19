using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventScreenTurnedOff : MonoBehaviour
{
    private static PreventScreenTurnedOff instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
    }
}
