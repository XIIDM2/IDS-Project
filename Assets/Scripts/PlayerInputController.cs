using System;
using UnityEngine;
using VContainer.Unity;

public class PlayerInputController : IInitializable, IDisposable
{
    public Vector2 MoveDirection => actions.Player.Move.ReadValue<Vector2>();
    public Vector2 LookDirection => actions.Player.Look.ReadValue<Vector2>();
    private InputSystem_Actions actions;

    public void Initialize()
    {
        actions = new InputSystem_Actions();

        actions.Enable();
    }

    public void Dispose()
    {
        actions.Dispose();
    }

}
