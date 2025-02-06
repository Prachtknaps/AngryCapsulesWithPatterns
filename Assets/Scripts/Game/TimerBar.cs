using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour, Observer
{
    private Image timerBar = null;

    private void Awake()
    {
        timerBar = GetComponent<Image>();
    }

    public void UpdateObserver()
    {
        float time = GameManager.GetTimer().GetTime();
        float totalTime = GameManager.GetTimer().GetTotalTime();
        timerBar.fillAmount = time / totalTime;
    }
}
