using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBall : PowerUp
{
    [SerializeField]
    float powerLength;
    [SerializeField]
    float speedScale;

    private new void Awake()
    {
        base.Awake();
        PlayerController.OnFasterBallPickup += Activate;
    }
    private new void Activate(Collision2D collision)
    {
        foreach (GameObject ball in currentBalls)
            ball.GetComponent<Ball>().FasterBall(powerLength, speedScale);
        base.Activate(collision);

    }

    
}
