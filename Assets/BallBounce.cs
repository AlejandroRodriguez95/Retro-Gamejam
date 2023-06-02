using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 11f;
    float playerYPosition = -4.5f;
    float playerXLength = 1;
    [SerializeField]
    float maxBounceAngle = 90;

    float PlayerYPosition {set { playerYPosition = value; }}
    float PlayerXPosition {set { playerXLength = value; }}

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    /// <summary>
    /// Basically, if you hit the player, recalculate the angle for the bounce
    /// otherwise, just reflect the bounce
    /// </summary>
    /// <param name="collision"></param>
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        float pointOfImpact = collision.contacts[0].point.x;
        float playerCenter = collision.gameObject.transform.position.x;
        float distanceFromCenter = pointOfImpact - playerCenter;
        float angle = maxBounceAngle*distanceFromCenter - maxBounceAngle;

        float angleInRadians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleInRadians);
        float y = Mathf.Abs(Mathf.Sin(angleInRadians));

        Vector2 direction = new Vector2(x, y).normalized;

        // Calculate the reflection vector using the direction and the surface normal

        rb.velocity = direction * speed;
    }
    else
    {
        Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflection.normalized * speed;
    }
}
}
