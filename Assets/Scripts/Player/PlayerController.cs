using UnityEngine;
using VContainer;

[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerLook look;
    private PlayerInputController input;

    [Inject]
    public void Construct(PlayerInputController input)
    {
        this.input = input;
    }

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
    }

    private void OnEnable()
    {
        input.InteractionButtonTriggered += Interact;
    }

    private void OnDisable()
    {
        input.InteractionButtonTriggered -= Interact;
    }

    private void Start()
    {
        movement.Construct(input);
        look.Construct(input);
    }

    private void Interact()
    {
        if (look.Interactable == null) return;

        look.Interactable.Interact();
    }


}
