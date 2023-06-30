using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : PowerUp
{

    [SerializeField]
    SO_LauncherSettings settings;
    [SerializeField]
    SO_AllyBossSettings allySettings;
    public static Action OnSpawnBallActivated;
    private new void OnEnable()
    {
        base.OnEnable();
        PlayerController.OnSpawnBallPickup += Activate;
    }
    // Start is called before the first frame update
    public new void Activate(Collision2D collision)
    {
        OnSpawnBallActivated?.Invoke();
    }
}
