using UnityEngine;

public class SkillBullet : Missle, IDamageDealer
{
    [SerializeField] private float explosionRadius;

    private void Update() 
    {
        CheckPosition();
    }

    public override void Launch(Weapon weapon)
    {
        rb.AddForce(weapon.transform.forward * weapon.FireForce);
    }

    public void Explode(Weapon weapon)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                DealDamage(enemy);
            }
        }

        weapon.ResetCooldown();
        Destroy();
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
