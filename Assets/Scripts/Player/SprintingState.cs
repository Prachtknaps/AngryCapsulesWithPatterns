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
        Debug.Log("Entering Sprinting State");
        player.SetMovementSpeed(4.5f);
    }

    public void UpdateState()
    {
        if (!player.IsMoving)
        {
            player.SetPlayerState(new IdleState(player));
        }
        else if (!player.IsSprinting)
        {
            player.SetPlayerState(new WalkingState(player));
        }
    }
}
