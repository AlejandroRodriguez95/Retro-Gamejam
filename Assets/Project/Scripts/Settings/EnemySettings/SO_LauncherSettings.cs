using UnityEngine;

[CreateAssetMenu(fileName = "LauncherSettings", menuName = "ScriptableObjects/LauncherSettings")]

public class SO_LauncherSettings : ScriptableObject
{
    public GameObject BallPrefab;
    public float BallInitialSpeed;
    public int MaxAmountOfBalls;
    public float BallsMinBounceAngle;
}
