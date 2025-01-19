using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetApplicationVersion : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    void Start()
    {
        displayText.text = "v" + Application.version;
    }
}
