using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour, Observer
{
    private TextMeshProUGUI scoreText = null;
    private ScoreManager scoreManager = null;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Observer.UpdateObserver()
    {
        if (scoreManager == null)
        {
            scoreManager = GameManager.Instance.GetScoreManager();
        }

        scoreText.text = "Score: " + scoreManager.GetScore();
    }
}
