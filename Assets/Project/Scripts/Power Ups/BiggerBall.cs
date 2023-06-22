using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerBall: PowerUp
{
    [SerializeField]
    float powerLength;
    [SerializeField]
    float sizeScale;

    private new void Awake()
    {
        base.Awake();
        PlayerController.OnBiggerBallPickup += Activate;
    }
    private new void Activate(Collision2D collision)
    {
        currentBall.GetComponent<Ball>().BiggerBall(powerLength,sizeScale);
        base.Activate(collision);

    }

    
}
