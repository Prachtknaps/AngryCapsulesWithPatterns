using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour, Observer
{
    private TextMeshProUGUI timerText = null;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateObserver()
    {
        float time = GameManager.Instance.GetTimer().GetTime();
        timerText.text = "Time Remaining: " + time + "s";
    }
}
