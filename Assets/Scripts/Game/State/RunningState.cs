using UnityEngine;

public class RunningState : IGameState
{
    public void Enter()
    {
        GameManager.GetMainMenu().SetActive(false);
        GameManager.GetPauseMenu().SetActive(false);
        GameManager.GetGameGUI().SetActive(true);
        GameManager.GetGameOverMenu().SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
