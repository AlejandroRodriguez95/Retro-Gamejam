using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LauncherBehavior : MonoBehaviour
{
    public static Action<GameObject> OnBallLaunch;
    private void Awake()
    {
        BallLauncher.OnLaunchBall += BallLaunch;
        Cannon.OnLaunchProjectile += ProjectileLaunch;
    }

    void BallLaunch(Queue<GameObject> ballQueue, Vector2 dir, float speed)
    {
        GameObject currentBall = ballQueue.Dequeue();
        OnBallLaunch?.Invoke(currentBall);
        var rb = currentBall.GetComponent<Rigidbody2D>();
        currentBall.SetActive(true);
        rb.velocity = dir * speed;
    }

    void ProjectileLaunch(Queue<GameObject> projectileQueue, Vector2 dir, float speed)
    {
        GameObject currentProjectile = projectileQueue.Dequeue();
        var rb = currentProjectile.GetComponent<Rigidbody2D>();
        currentProjectile.SetActive(true);
        rb.velocity = dir * speed;
    }
}
