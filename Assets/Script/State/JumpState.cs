using UnityEngine;

public class JumpState : IState
{
    private PlayerController player;

    public JumpState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Velocity.y = player.jumpForce;
    }

    public void Update()
    {
        Vector2 input = player.MoveInput;
        Vector3 airMove = new Vector3(input.x, 0, input.y) * player.moveSpeed;
        player.CharController.Move(airMove * Time.deltaTime);

        if (airMove != Vector3.zero)
        {
            player.transform.forward = airMove;
        }

        if (player.CharController.isGrounded || player.IsGrounded)
        {
            player.PlayerStateMachine.TransitionTo(player.LocomotionState);
        }
    }
}
