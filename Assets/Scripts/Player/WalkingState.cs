using UnityEngine;

public class WalkingState : IPlayerState
{
    private PlayerController player;

    public WalkingState(PlayerController playerController)
    {
        player = playerController;
    }

    public void EnterState()
    {
        player.SetMovementSpeed(2.0f);
    }

    public void UpdateState()
    {
        player.CheckForStateChange();
    }
}
