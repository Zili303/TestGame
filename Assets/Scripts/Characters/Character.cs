using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    public event Action<float> OnCurrentHealthChange;
    public event Action<float> OnMaxHealthChange;
    public event Action OnDamageTaken;

    public virtual void ModifyHealth(float value)
    {
        CurrentHealth = value;
        OnCurrentHealthChange?.Invoke(CurrentHealth);
    }

    public virtual void ModifyMaxHealth(float value)
    {
        MaxHealth = value;
        OnMaxHealthChange?.Invoke(MaxHealth);
    }

    public virtual void TakeDamage(float amout)
    {
        ModifyHealth(CurrentHealth - amout);
        OnDamageTaken?.Invoke();
    }
}
