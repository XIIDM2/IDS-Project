using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private float interactableDistance = 2f;
    public IInteractable Interactable {  get; private set; }

    private const float MAX_CAMERA_ROTATION_OFFSET = 90.0f;
    private float verticalRotationOffset;

    private PlayerInputController input;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Rotate();
        CheckInteractionVisible();
    }

    public void Construct(PlayerInputController input)
    {
        this.input = input;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * input.LookDirection.x);

        verticalRotationOffset = Mathf.Clamp(verticalRotationOffset - rotationSpeed * input.LookDirection.y, -MAX_CAMERA_ROTATION_OFFSET, MAX_CAMERA_ROTATION_OFFSET);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotationOffset, 0, 0);
    }

    private void CheckInteractionVisible()
    {
        //Ray from screen center
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        IInteractable interactable = null;

        if (Physics.Raycast(ray, out RaycastHit hit, interactableDistance)) interactable = hit.transform.GetComponent<IInteractable>();

        if (Interactable == interactable) return;

        Interactable = interactable;
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(ray);
    }
}
