using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour, Observer
{
    private TextMeshProUGUI scoreText = null;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateObserver()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScoreManager().GetScore();
    }
}
