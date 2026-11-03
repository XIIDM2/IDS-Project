using UnityEngine;
using VContainer;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    private const float MAX_CAMERA_ROTATION_OFFSET = 90.0f;
    private float verticalRotationOffset;

    private PlayerInputController input;
    private CharacterController controller;
    private Camera playerCamera;


    [Inject]
    public void Construct(PlayerInputController input)
    {
        this.input = input;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 moveVector = moveSpeed * Time.deltaTime * new Vector3(input.MoveDirection.x, 0, input.MoveDirection.y);

        Vector3 movement = transform.TransformDirection(moveVector);

        controller.Move(movement);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * input.LookDirection.x);

        verticalRotationOffset = Mathf.Clamp(verticalRotationOffset - rotationSpeed * input.LookDirection.y, -MAX_CAMERA_ROTATION_OFFSET, MAX_CAMERA_ROTATION_OFFSET);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotationOffset, 0, 0);
    }
}
