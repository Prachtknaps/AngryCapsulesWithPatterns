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
        Debug.Log("Entering Idle State");
        player.SetMovementSpeed(0.0f);
    }

    public void UpdateState()
    {
        if (player.IsMoving)
        {
            if (player.IsSprinting)
            {
                player.SetPlayerState(new SprintingState(player));
            }
            else
            {
                player.SetPlayerState(new WalkingState(player));
            }
        }
    }

}
