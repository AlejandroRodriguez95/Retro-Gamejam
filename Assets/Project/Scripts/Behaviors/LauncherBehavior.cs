using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LauncherBehavior : MonoBehaviour
{
    private void Awake()
    {
        BallLauncher.OnLaunchBall += Launch;
        Cannon.OnLaunchProjectile += Launch;
    }

    void Launch(Queue<GameObject> projectileQueue, Vector2 dir, float speed)
    {
        var currentBall = projectileQueue.Dequeue();
        var rb = currentBall.GetComponent<Rigidbody2D>();
        currentBall.SetActive(true);
        rb.velocity = dir * speed;
    }
}
