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
        float time = GameManager.Instance.GetTimer().GetTime();
        float totalTime = GameManager.Instance.GetTimer().GetTotalTime();
        timerBar.fillAmount = time / totalTime;
    }
}
