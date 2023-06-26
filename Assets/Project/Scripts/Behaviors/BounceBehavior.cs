using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehavior : MonoBehaviour
{
    void Start()
    {
        Ball.OnBallBouncesNormally += NormalBounce;
        Ball.OnBallBouncesOnPlayer += BounceOnPlayer;

        EnemyProjectile.OnProjectileBouncesNormally += NormalBounce;
        EnemyProjectile.OnProjectileBouncesOnPlayer += BounceOnPlayer;
    }
    private void NormalBounce(Collision2D collision, float ballInitialSpeed)
    {
        Vector2 reflection = Vector2.Reflect(collision.otherRigidbody.velocity, collision.contacts[0].normal);
        collision.otherRigidbody.velocity = reflection.normalized * ballInitialSpeed;
 /*       float xPos = collision.otherRigidbody.position.x;
        float yPos = collision.otherRigidbody.position.y;
        float ballRadius = collision.otherCollider.bounds.extents.x;

        xPos = Mathf.Clamp(collision.otherRigidbody.position);
 */   }

    private void BounceOnPlayer(Collision2D collision, float ballInitialSpeed, float minBounceAngle, float maxBounceAngle)
    {
        float pointOfImpact = collision.contacts[0].point.x;
        float playerCenter = collision.gameObject.transform.position.x;
        float distanceFromCenter = pointOfImpact - playerCenter;
        float angle = maxBounceAngle * (1 - Mathf.Abs(distanceFromCenter));

        if (distanceFromCenter > 0)
            angle = Mathf.Clamp(angle, minBounceAngle, maxBounceAngle);
        else
            angle = Mathf.Clamp(180 - angle, 180 - maxBounceAngle, 180 - minBounceAngle);

        float angleInRadians = angle * Mathf.Deg2Rad;

        //x and y component from the direction vector
        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Abs(Mathf.Sin(angleInRadians));

        Vector2 direction = new Vector2(x, y).normalized;

        collision.otherRigidbody.velocity = direction * ballInitialSpeed;
    }
}
