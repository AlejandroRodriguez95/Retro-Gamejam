using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Title("Ball launcher settings")]
    [SerializeField]
    private BallLauncher ballLauncherReference;
    [SerializeField]
    private float ballsInitialSpeed;
    [SerializeField]
    private float minBallBounceAngle;
    [SerializeField]
    private float maxBallBounceAngle;
    [SerializeField]
    private int maxAmountOfBalls; // maximum amount of balls on the screen at any given time 

    [Space]
    [Title("Player controller settings")]
    [SerializeField]
    PlayerController playerController;
    [Tooltip("bounds for player movement in the X axis (how far can the player go to the left and right)")]
    [SerializeField] float bounds;

    [Space]
    [Title("Internal")]
    [SerializeField]
    GameObject ballPrefab;


    private void Awake()
    {
        InitializeBallBounceValues();
        InitializePlayerControllerValues();
    }


    private void InitializeBallBounceValues()
    {
        ballLauncherReference.BallInitialSpeed = ballsInitialSpeed;
        ballLauncherReference.MaxAmountOfBalls = maxAmountOfBalls;
        ballLauncherReference.BallPrefab = ballPrefab;
        ballLauncherReference.BallsMaxBounceAngle = maxBallBounceAngle;
        ballLauncherReference.BallsMinBounceAngle = minBallBounceAngle;
    }

    private void InitializePlayerControllerValues()
    {
        playerController.Bounds = bounds;
    }

}
