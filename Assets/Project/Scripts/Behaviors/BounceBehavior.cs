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
        float displacementFromCenter = pointOfImpact - playerCenter;

        float playerExtent = collision.gameObject.GetComponent<PlayerController>().Bounds / 2;
        float tempHeight = playerExtent * Mathf.Tan(minBounceAngle*Mathf.PI/360) ;
        float reflectionAngle = Mathf.Atan2(displacementFromCenter, tempHeight);

        float x = Mathf.Sin(reflectionAngle);
        float y = Mathf.Cos(reflectionAngle);

        Vector2 direction = new Vector2(x, y).normalized;

        collision.otherRigidbody.velocity = direction * ballInitialSpeed;
    }
}
