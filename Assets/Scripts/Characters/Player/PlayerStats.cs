using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Game/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int Level;
    public float ExperienceToNextLevel;
    public float MaxHealth;
    public float MoveSpeed;
    public float SkillCooldown;
    public float BulletDamage;
    public float SkillDamage;
}
