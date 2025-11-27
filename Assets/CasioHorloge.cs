using UnityEngine;
using UnityEngine.UI;
using System;

public class WatchTime : MonoBehaviour
{
    public Text timeText;

    void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
