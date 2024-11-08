using UnityEngine;

public class SprintingState : IPlayerState
{
    private PlayerController player;

    public SprintingState(PlayerController playerController)
    {
        player = playerController;
    }

    public void EnterState()
    {
        player.SetMovementSpeed(4.5f);
    }

    public void UpdateState()
    {
        player.CheckForStateChange();
    }
}
