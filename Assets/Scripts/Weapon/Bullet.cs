using UnityEngine;

public class Bullet : Missle, IDamageDealer
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            DealDamage(enemy);
            Destroy();
        }
    }

    private void Update() 
    {
        CheckPosition();
    }

    public override void Launch(Weapon weapon)
    {
        weapon.ResetCooldown();
        rb.AddForce(weapon.transform.forward * weapon.FireForce);
    }

    public override void Destroy()
    {
        base.Destroy();
        misslePool.ReturnToPool(this);
    }

    public void DealDamage(Character target)
    {
        target.TakeDamage(damage);
    }
}
