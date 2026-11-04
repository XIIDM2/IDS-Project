using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

public class PlayerInputController : IInitializable, IDisposable
{
    public event Action InteractionButtonTriggered;
    public Vector2 MoveDirection => actions.Player.Move.ReadValue<Vector2>();
    public Vector2 LookDirection => actions.Player.Look.ReadValue<Vector2>();
    private InputSystem_Actions actions;

    public void Initialize()
    {
        actions = new InputSystem_Actions();

        actions.Player.Interact.performed += OnInteractionButtonTriggered;

        actions.Enable();
    }

    public void Dispose()
    {
        actions.Player.Interact.performed -= OnInteractionButtonTriggered;

        actions.Dispose();
    }

    private void OnInteractionButtonTriggered(InputAction.CallbackContext context) => InteractionButtonTriggered?.Invoke();

}
