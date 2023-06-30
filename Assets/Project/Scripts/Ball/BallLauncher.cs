using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    SO_LauncherSettings settings;
    [SerializeField]
    SO_AllyBossSettings allySettings;

    public static Action<Queue<GameObject>, Vector2, float> OnLaunchBall;

    Queue<GameObject> ballQueue;

    void Start()
    {
        Ball.OnBallTouchesBottom += ReQueueBall;
        SpawnBall.OnSpawnBallActivated += LaunchBall;
        
        ballQueue = new Queue<GameObject>(settings.MaxAmountOfBalls);

        for(int i=0; i<settings.MaxAmountOfBalls; i++)
        {
            var tempBall = Instantiate(settings.BallPrefab, transform);
            var bh = tempBall.GetComponent<Ball>();

            bh.BallInitialSpeed = settings.BallInitialSpeed;
            bh.MaxBounceAngle = settings.BallsMaxBounceAngle;
            bh.MinBounceAngle = settings.BallsMinBounceAngle;
            bh.DamageDealt = allySettings.DamageFromBall;
            ballQueue.Enqueue(tempBall);
        }

        StartCoroutine(LaunchBallAfterTime());
    }


    void ReQueueBall(GameObject ball)
    {
        ballQueue.Enqueue(ball);

        StartCoroutine(LaunchBallAfterTime()); // temp
    }

    // temp coroutine to keep the ball launching
    IEnumerator LaunchBallAfterTime()
    {
        yield return new WaitForSeconds(3);
        OnLaunchBall?.Invoke(ballQueue, Vector2.up, settings.BallInitialSpeed);
    }

    void LaunchBall() {
        OnLaunchBall?.Invoke(ballQueue, Vector2.up, settings.BallInitialSpeed);
    }
}
