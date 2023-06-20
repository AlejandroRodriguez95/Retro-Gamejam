using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBall : PowerUp
{
    [SerializeField]
    float powerLength;
    [SerializeField]
    float speedScale;

    GameObject activeBall;

    private new void Awake()
    {
        Ball.OnBallBouncesOnPlayer += SetActiveBall;
        base.Awake();
        PlayerController.OnFasterBallPickup += Activate;
    }
    private new void Activate(Collision2D collision) {
        Rigidbody2D rb = activeBall.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity *= speedScale;
        base.Activate(collision);
        StartCoroutine(SlowDown(rb));
        
    }

    IEnumerator SlowDown(Rigidbody2D rb) {
        
        yield return new WaitForSeconds(powerLength);
        rb.velocity /= speedScale;
    }

    void SetActiveBall(Collision2D collision, float BallInitialSpeed,float minBounceAngle, float maxBounceAngle)
    {
        activeBall = collision.otherCollider.gameObject;
    }
}
