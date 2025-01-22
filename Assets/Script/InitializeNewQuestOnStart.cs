using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitializeNewQuestOnStart : MonoBehaviour
{
    public UnityEvent onStart;

    private bool invoked = false;

    private void Update()
    {
        if (!invoked)
        {
            onStart.Invoke();
            invoked = true;
        }
    }
}
