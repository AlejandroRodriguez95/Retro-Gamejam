using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Title("Ball launcher")]
    [SerializeField]
    private BallLauncher ballLauncherReference;
    [SerializeField]
    private float ballsInitialSpeed;
    [SerializeField]
    private int maxAmountOfBalls; // maximum amount of balls on the screen at any given time 
    [SerializeField]
    GameObject ballPrefab;

    private void Awake()
    {
        InitializeBallBounceValues();
    }


    private void InitializeBallBounceValues()
    {
        ballLauncherReference.BallInitialSpeed = ballsInitialSpeed;
        ballLauncherReference.MaxAmountOfBalls = maxAmountOfBalls;
        ballLauncherReference.BallPrefab = ballPrefab;
    }
}
