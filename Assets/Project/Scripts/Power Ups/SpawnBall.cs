using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : PowerUp
{

    [SerializeField]
    SO_LauncherSettings settings;
    public static Action<Vector2> OnSpawnBallActivated;
    private new void Awake()
    {
        base.Awake();
        PlayerController.OnSpawnBallPickup += Activate;
    }
    // Start is called before the first frame update
    public new void Activate(Collision2D collision)
    {
        GameObject ball = Instantiate(settings.BallPrefab);

        ball.transform.position = collision.transform.position;

        var bh = ball.GetComponent<Ball>();
        bh.BallInitialSpeed = settings.BallInitialSpeed;
        bh.MaxBounceAngle = settings.BallsMaxBounceAngle;
        bh.MinBounceAngle = settings.BallsMinBounceAngle;

        var rb = ball.GetComponent<Rigidbody2D>();

        ball.SetActive(true);

        rb.velocity = Vector2.up * bh.BallInitialSpeed;
        base.Activate(collision);
    }
}
