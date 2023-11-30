using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private WeaponInput weaponInput;
    private Launcher launcher;
    private Player player;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private bool isBurst;
    private float nextFireTime;

    public float FireForce = 300f;

    public event Action<float> OnCooldownChange;

    private void OnEnable() 
    {
        if (isBurst)
        {
            weaponInput.OnWeaponBurstFire += FireWeapon;
        }
        else
        {
            weaponInput.OnWeaponSingleFire += FireWeapon;
        }   
    }

    private void OnDisable() 
    {
        if (isBurst)
        {
            weaponInput.OnWeaponBurstFire -= FireWeapon;
        }
        else
        {
            weaponInput.OnWeaponSingleFire -= FireWeapon;
        }
    }

    private void Awake() 
    {
        weaponInput = GetComponent<WeaponInput>();
        launcher = GetComponent<Launcher>();
        player = FindObjectOfType<Player>();
    }

    private void Update() 
    {
        RunCooldown();
    }

    private bool CanFire()
    {
        return nextFireTime <= 0f;
    }

    public void ResetCooldown()
    {
        nextFireTime = cooldown;
    }

    public void SetCooldown(float value)
    {
        cooldown = value;
    }

    private void RunCooldown()
    {
        nextFireTime -= Time.deltaTime;
        if (nextFireTime < 0f)
        {
            nextFireTime = 0f;
        }

        OnCooldownChange?.Invoke(nextFireTime);
    }

    private void FireWeapon()
    {
        if (CanFire())
        {
            launcher.Launch(this);
        }
    }
}
