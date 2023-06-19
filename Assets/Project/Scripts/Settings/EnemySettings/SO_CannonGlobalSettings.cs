using UnityEngine;

[CreateAssetMenu(fileName = "CannonGlobalSettings", menuName = "ScriptableObjects/CannonGlobalSettings")]
public class SO_CannonGlobalSettings : ScriptableObject
{
    public GameObject EnemyProjectilePrefab;
    public float ProjectileInitialSpeed;

    public int MaxQueueCapacity = 10;
}