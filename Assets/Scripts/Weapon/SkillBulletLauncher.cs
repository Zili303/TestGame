using UnityEngine;

public class SkillBulletLauncher : Launcher
{
    [SerializeField] private GameStateController gameStateController;

    [Space]

    [SerializeField] private MisslePool skillBulletPool;
    private SkillBullet missle;
    private float cooldown;
    private bool canFire;

    protected override void OnEnable() 
    {
        base.OnEnable();
        gameStateController.OnGameStart += onGameStart;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        gameStateController.OnGameStart -= onGameStart;
    }

    private void onGameStart()
    {
        RestartMissle();
    }

    public override void Launch(Weapon weapon)
    {
        if (canFire)
        {
            missle = (SkillBullet)skillBulletPool.Get();
            missle.transform.position = transform.position;
            missle.transform.rotation = transform.rotation;
            missle.SetDamage(damage);
            missle.SetPool(skillBulletPool);
            missle.gameObject.SetActive(true);
            weapon.SetCooldown(cooldown);
            missle.Launch(weapon);
            canFire = false;
        }
        else
        {
            missle.Explode(weapon);
            RestartMissle();
        }
    }

    public override void LevelUp(PlayerStats playerLevel)
    {
        damage = playerLevel.SkillDamage;
        cooldown = playerLevel.SkillCooldown;

        Debug.Log("CD: " + cooldown);
        Debug.Log("DAMAGE: " + damage);
    }

    public void RestartMissle()
    {
        canFire = true;
    }
}
