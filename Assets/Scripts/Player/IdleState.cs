using UnityEngine;

public class IdleState : IPlayerState
{
    private PlayerController player;

    public IdleState(PlayerController playerController)
    {
        player = playerController;
    }

    public void EnterState()
    {
        player.SetMovementSpeed(0.0f);
    }

    public void UpdateState()
    {
        player.CheckForStateChange();
    }
}
