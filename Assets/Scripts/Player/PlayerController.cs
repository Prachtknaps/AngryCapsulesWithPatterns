using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private bool allowSprinting = true;
    [SerializeField] private bool allowJumping = true;

    [Header("Audio")]
    [SerializeField] private AudioClip collectItemSound = null;
    private AudioSource audioSource = null;

    public bool CanMove { get; private set; } = true;
    public Vector3 MovementVector { get => movementVector; set => movementVector = value; }
    public bool IsMoving => Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f;
    public bool IsGrounded => playerController.isGrounded;
    public bool IsSprinting => allowSprinting && Input.GetKey(sprintKey);
    public bool ShouldJump => Input.GetKeyDown(jumpKey) && IsGrounded;

    private IPlayerState playerState;

    // Movement
    private float movementSpeed = 0.0f;
    private float gravity = -9.81f;
    private Vector3 movementVector = Vector3.zero;
    private Vector2 movementInput = Vector2.zero;

    // Rotation
    private float mouseSensitivityX = 2.0f;
    private float mouseSensitivityY = 1.5f;
    private float maxLookUp = -60.0f;
    private float maxLookDown = 80.0f;
    private float verticalRotation = 0.0f;

    // Key Bindings
    private KeyCode sprintKey = KeyCode.LeftShift;
    private KeyCode jumpKey = KeyCode.Space;

    private CharacterController playerController = null;
    private Transform playerHead = null;
    private Camera playerCamera = null;

    private IWeapon weapon = null;

    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerHead = transform.GetChild(0);
        playerCamera = playerHead.GetComponentInChildren<Camera>();
        audioSource = GetComponent<AudioSource>();

        SetPlayerState(new IdleState(this));
    }

    void Update()
    {
        if (CanMove && GameManager.Instance.GetState() is RunningState)
        {
            playerState.UpdateState();

            ProcessMovement();
            ProcessRotation();

            if (allowJumping)
            {
                ProcessJump();
            }

            ProcessShooting();

            MovePlayer();
        }
    }

    public void SetPlayerState(IPlayerState state)
    {
        playerState = state;
        playerState.EnterState();
    }

    public void CheckForStateChange()
    {
        if (ShouldJump)
        {
            SetPlayerState(new JumpingState(this));
        }
        else if (IsSprinting && IsMoving)
        {
            SetPlayerState(new SprintingState(this));
        }
        else if (IsMoving)
        {
            SetPlayerState(new WalkingState(this));
        }
        else
        {
            SetPlayerState(new IdleState(this));
        }
    }

    public void SetWeapon(IWeapon weapon)
    {
        audioSource.clip = collectItemSound;
        audioSource.Play();
        this.weapon = weapon;
    }


    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    private void ProcessMovement()
    {
        movementInput = new Vector2(movementSpeed * Input.GetAxis("Vertical"), movementSpeed * Input.GetAxis("Horizontal"));

        float movementVectorY = movementVector.y;
        movementVector = (transform.TransformDirection(Vector3.forward) * movementInput.x) + (transform.TransformDirection(Vector3.right) * movementInput.y);
        movementVector.y = movementVectorY;
    }

    private void ProcessRotation()
    {
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalRotation = Mathf.Clamp(verticalRotation, maxLookUp, maxLookDown);
        playerHead.transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);

        transform.rotation *= Quaternion.Euler(0.0f, Input.GetAxis("Mouse X") * mouseSensitivityX, 0.0f);
    }

    private void ProcessJump()
    {
        if (ShouldJump)
        {
            SetPlayerState(new JumpingState(this));
        }
    }

    private void MovePlayer()
    {
        if (!IsGrounded)
        {
            movementVector.y += gravity * Time.deltaTime;
        }

        playerController.Move(movementVector * Time.deltaTime);
    }

    private void ProcessShooting()
    {
        if (weapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.ShootStrategy is BalloonShotStrategy)
            {
                weapon.Shoot();
            }

            if (Input.GetKey(KeyCode.Mouse0) && weapon.ShootStrategy is ContinuousShotStrategy)
            {
                weapon.Shoot();
            }
        }
    }
}
