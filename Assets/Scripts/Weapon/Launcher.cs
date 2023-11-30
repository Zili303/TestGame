using UnityEngine;

public abstract class Launcher : MonoBehaviour
{
    protected PlayerLevelSystem playerLevelSystem;
    protected float damage;

    protected virtual void OnEnable() 
    {
        playerLevelSystem.OnPlayerLevelUp += LevelUp;
    }

    protected virtual void OnDisable() 
    {
        playerLevelSystem.OnPlayerLevelUp -= LevelUp;
    }

    private void Awake() 
    {
        playerLevelSystem = FindObjectOfType<PlayerLevelSystem>();
    }

    public abstract void Launch(Weapon weapon);

    public abstract void LevelUp(PlayerStats playerLevel);
}
