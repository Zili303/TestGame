using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private GameStateController gameStateController;

    [Space]

    [SerializeField] private InputActionReference fireWeaponAction;

    public event Action OnWeaponSingleFire;
    public event Action OnWeaponBurstFire;

    private void OnEnable() 
    {
        gameStateController.OnGameStart += onGameStart;
        gameStateController.OnGameEnd += onGameEnd;
    }

    private void OnDisable() 
    {
        gameStateController.OnGameStart -= onGameStart;
        gameStateController.OnGameEnd -= onGameEnd;
    }

    private void onGameStart()
    {
        EnableInput(); 
    }

    private void onGameEnd()
    {
        DisableInput(); 
    }

    public void EnableInput() 
    {
        fireWeaponAction.action.Enable();
    }

    public void DisableInput() 
    {
        fireWeaponAction.action.Disable();
    }

    private void Update() 
    {
        if (fireWeaponAction.action.WasPerformedThisFrame())
        {
            OnWeaponSingleFire?.Invoke();
        }
        else if (fireWeaponAction.action.IsPressed())
        {
            OnWeaponBurstFire?.Invoke();
        }
    }
}
