using UnityEngine;

public class BulletLauncher : Launcher
{
    [SerializeField] private MisslePool bulletPool;

    public override void Launch(Weapon weapon)
    {
        var missle = bulletPool.Get();

        missle.transform.position = transform.position;
        missle.transform.rotation = transform.rotation;
        missle.SetDamage(damage);
        missle.SetPool(bulletPool);
        missle.gameObject.SetActive(true);
        missle.Launch(weapon);
    }

    public override void LevelUp(PlayerStats playerLevel)
    {
        damage = playerLevel.BulletDamage;
    }
}
