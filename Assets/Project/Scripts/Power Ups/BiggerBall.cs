using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerBall: PowerUp
{
    [SerializeField]
    float powerLength;
    [SerializeField]
    float sizeScale;

    private new void OnEnable()
    {
        base.OnEnable();
        PlayerController.OnBiggerBallPickup += Activate;
    }
    private new void Activate(Collision2D collision)
    {
        foreach(GameObject ball in currentBalls)
            ball.GetComponent<Ball>().BiggerBall(powerLength, sizeScale);
        base.Activate(collision);

    }

    
}
