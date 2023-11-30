using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missle : MonoBehaviour
{
    [SerializeField] protected MapSettings mapSettings;
    protected Rigidbody rb;
    protected float damage;
    protected MisslePool misslePool;

    protected void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void Launch(Weapon weapon);

    public void CheckPosition()
    {
        if (transform.position.z > mapSettings.StartZPosition)
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        rb.velocity = Vector3.zero;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    public void SetPool(MisslePool pool)
    {
        misslePool = pool;
    }
}
