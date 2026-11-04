using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private PlayerInputController input;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Construct(PlayerInputController input)
    {
        this.input = input;
    }
    private void Move()
    {
        Vector3 moveVector = moveSpeed * Time.deltaTime * new Vector3(input.MoveDirection.x, 0, input.MoveDirection.y);

        Vector3 movement = transform.TransformDirection(moveVector);

        controller.Move(movement);
    }
}
