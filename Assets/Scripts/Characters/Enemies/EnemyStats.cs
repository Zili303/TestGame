using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Game/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public float MaxHealth;
    public float Speed;
    public float Damage;
    public float SpawnChance;
    public int ScoreForKill;
    public int ExperienceForKill;
}
