using UnityEngine;

public class JumpingState : IPlayerState
{
    private PlayerController player;
    private float jumpForce = 4.5f;

    public JumpingState(PlayerController playerController)
    {
        player = playerController;
    }

    public void EnterState()
    {
        player.MovementVector = new Vector3(player.MovementVector.x, jumpForce, player.MovementVector.z);
    }

    public void UpdateState()
    {
        player.CheckForStateChange();
    }
}
