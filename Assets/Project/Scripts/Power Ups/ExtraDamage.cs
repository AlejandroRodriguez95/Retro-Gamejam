using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDamage : PowerUp
{
    [SerializeField]
    float powerLength;
    [SerializeField]
    int damageScale;

    private new void OnEnable()
    {
        base.OnEnable();
        PlayerController.OnExtraDamagePickup += Activate;
    }
    private new void Activate(Collision2D collision)
    {
        foreach (GameObject ball in currentBalls)
            ball.GetComponent<Ball>().ExtraDamage(powerLength, damageScale);
        base.Activate(collision);

    } 
}
