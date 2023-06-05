using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    //settings
    private float ballInitialSpeed;
    private int maxAmountOfBalls;
    private float ballsMaxBounceAngle;
    private float ballsMinBounceAngle;

    private AudioClip ballBounceClip;

    GameObject ballPrefab;

    GameObject currentBall;
    Queue<GameObject> ballQueue;

    #region Getters&Setters
    public float BallInitialSpeed { get { return ballInitialSpeed; } set { ballInitialSpeed = value; }}
    public int MaxAmountOfBalls { get { return maxAmountOfBalls; } set { maxAmountOfBalls = value; }}
    public GameObject BallPrefab { get { return ballPrefab; } set { ballPrefab = value; } }
    public float BallsMaxBounceAngle { get { return ballsMaxBounceAngle; } set { ballsMaxBounceAngle = value; }}
    public float BallsMinBounceAngle { get { return ballsMinBounceAngle; } set { ballsMinBounceAngle = value; }}
    public AudioClip BallBounceClip { get { return ballBounceClip; } set { ballBounceClip = value; } }
    #endregion

    void Start()
    {
        BallBehavior.OnBallTouchesBottom += ReQueueBall;

        ballQueue = new Queue<GameObject>(maxAmountOfBalls);

        for(int i=0; i<maxAmountOfBalls; i++)
        {
            var tempBall = Instantiate(ballPrefab, transform);
            var bh = tempBall.GetComponent<BallBehavior>();

            bh.AudioSource.clip = ballBounceClip;

            bh.MaxBounceAngle = ballsMaxBounceAngle;
            bh.MinBounceAngle = ballsMinBounceAngle;
            ballQueue.Enqueue(tempBall);
        }

        StartCoroutine(LaunchBallAfterTime());
    }


    void LaunchBall()
    {
        currentBall = ballQueue.Dequeue();
        currentBall.SetActive(true);
        currentBall.GetComponent<BallBehavior>().LaunchBall();
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
        LaunchBall();
    }
}
