using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Player settings")]
public class SO_PlayerSettings : ScriptableObject
{
    public int MaxHealth;
    public int MoveSpeed;
    public float Bounds;
}