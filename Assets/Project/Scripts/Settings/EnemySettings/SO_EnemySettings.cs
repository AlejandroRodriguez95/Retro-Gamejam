using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/Enemy settings")]
public class SO_EnemySettings : ScriptableObject
{
    public int maxHealth;
    public float attackCooldown;
}