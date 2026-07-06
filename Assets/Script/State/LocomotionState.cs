using UnityEngine;

public class LocomotionState : IState
{
    private PlayerController player;

    public LocomotionState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Velocity.y = -2f;
    }

    public void Update()
    {
        Vector2 input = player.MoveInput;
        Vector3 move = new Vector3(input.x, 0, input.y) * player.moveSpeed;
        player.CharController.Move(move * Time.deltaTime);

        if (move != Vector3.zero)
        {
            player.transform.forward = move;
        }

        if (player.JumpPressed)
        {
            player.PlayerStateMachine.TransitionTo(player.JumpState);
        }
    }
}
