using UnityEngine;

public class PauseMenuState : IGameState
{
    public void Enter()
    {
        GameManager.GetMainMenu().SetActive(false);
        GameManager.GetPauseMenu().SetActive(true);
        GameManager.GetGameOverMenu().SetActive(false);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
