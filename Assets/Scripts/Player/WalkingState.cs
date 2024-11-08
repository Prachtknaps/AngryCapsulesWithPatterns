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
        Debug.Log("Entering Walking State");
        player.SetMovementSpeed(2.0f);
    }

    public void UpdateState()
    {
        if (!player.IsMoving)
        {
            player.SetPlayerState(new IdleState(player));
        }
        else if (player.IsSprinting)
        {
            player.SetPlayerState(new SprintingState(player));
        }
    }
}
