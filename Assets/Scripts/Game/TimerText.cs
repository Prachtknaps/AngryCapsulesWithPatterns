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
        float time = GameManager.GetTimer().GetTime();
        timerText.text = "Time Remaining: " + time + "s";
    }
}
