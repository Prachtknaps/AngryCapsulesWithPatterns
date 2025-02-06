using UnityEngine;

public class MainMenuState : IGameState
{
    public void Enter()
    {
        GameManager.GetMainMenu().SetActive(true);
        GameManager.GetPauseMenu().SetActive(false);
        GameManager.GetGameGUI().SetActive(false);
        GameManager.GetGameOverMenu().SetActive(false);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
