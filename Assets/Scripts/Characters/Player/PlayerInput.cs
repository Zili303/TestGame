using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputActions inputActions;

    public event Action<Vector2> OnPlayerMove;

    public void EnableInput() 
    {
        inputActions.UI.Disable();
        inputActions.Gameplay.Enable();
    }

    public void DisableInput() 
    {
        inputActions.Gameplay.Disable();
        inputActions.UI.Enable();
    }

    private void Awake()
    {
        inputActions = new InputActions();
    }

    private void Update()
    {
        CheckPlayerMoveAction();
    }

    private void CheckPlayerMoveAction()
    {
        OnPlayerMove?.Invoke(inputActions.Gameplay.PlayerMove.ReadValue<Vector2>());
    }
}
