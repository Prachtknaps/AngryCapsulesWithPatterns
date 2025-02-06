using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        GameManager.GetMainMenu().SetActive(false);
        GameManager.GetPauseMenu().SetActive(false);
        GameManager.GetGameGUI().SetActive(false);
        GameManager.GetGameOverMenu().SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        BuildGameOverScreen();
    }

    private static void BuildGameOverScreen()
    {
        int score = GameManager.GetScoreManager().GetScore();

        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        int highscore = PlayerPrefs.GetInt("Highscore");

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        GameManager.GetHighScoreText().text = "Highscore: " + highscore;
        GameManager.GetNewHighScoreText().text = (score >= highscore) ? "Score: " + score : "";
        GameManager.GetGameScoreText().text = (score >= highscore) ? "" : "Score: " + score;
    }
}
