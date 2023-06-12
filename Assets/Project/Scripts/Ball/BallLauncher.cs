using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    SO_LauncherSettings settings;

    public static Action<Queue<GameObject>, Vector2, float> OnLaunchBall;

    Queue<GameObject> ballQueue;

    void Start()
    {
        BallBehavior.OnBallTouchesBottom += ReQueueBall;
        
        ballQueue = new Queue<GameObject>(settings.MaxAmountOfBalls);

        for(int i=0; i<settings.MaxAmountOfBalls; i++)
        {
            var tempBall = Instantiate(settings.BallPrefab, transform);
            var bh = tempBall.GetComponent<BallBehavior>();

            bh.BallInitialSpeed = settings.BallInitialSpeed;
            bh.MinBounceAngle = settings.BallsMinBounceAngle;
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
}
