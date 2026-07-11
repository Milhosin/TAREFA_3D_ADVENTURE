/*using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -20f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    [Header("Componentes")]
    public CharacterController CharController;

    public StateMachine PlayerStateMachine;
    public LocomotionState LocomotionState;
    public JumpState JumpState;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    [HideInInspector] public Vector3 Velocity;

    private PlayerInput inputActions;    

    public bool IsGrounded
    {
        get
        {
            Vector3 origin = transform.position + Vector3.up * 0.1f;
            return Physics.Raycast(origin, Vector3.down, groundCheckDistance, groundLayer);
        }
    }

    void Awake()
    {
        CharController = GetComponent<CharacterController>();

        PlayerStateMachine = new StateMachine();
        LocomotionState = new LocomotionState(this);
        JumpState = new JumpState(this);
    }

    void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerInput();
        }

        inputActions.Enable();
    }

    void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.Disable();
        }
    }



    void Start()
    {
        if (PlayerStateMachine == null)
        {
            PlayerStateMachine = new StateMachine();
            LocomotionState = new LocomotionState(this);
            JumpState = new JumpState(this);
        }

        PlayerStateMachine.Initialize(LocomotionState);
    }

    void Update()
    {
        if (inputActions == null || PlayerStateMachine == null) return;

        MoveInput = inputActions.Player.move.ReadValue<Vector2>();
        JumpPressed = inputActions.Player.jump.triggered;

        if (JumpPressed && IsGrounded && PlayerStateMachine.CurrentState != JumpState)
        {
            PlayerStateMachine.TransitionTo(JumpState);
        }

        if (IsGrounded)
        {
            Velocity.y = -2f;
        }
        else
        {
            Velocity.y += gravity * Time.deltaTime;
        }

        PlayerStateMachine.Update();

        CharController.Move(new Vector3(0, Velocity.y, 0) * Time.deltaTime);
    }
}
*/