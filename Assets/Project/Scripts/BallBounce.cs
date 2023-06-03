using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody2D rb;

    float ballSpeed = 11f;
    float maxBounceAngle = 90;

    //these values are modified either through the inspector or assigned by the game manager

    #region Getters&Setters
    public float BallSpeed { get { return ballSpeed; } set { ballSpeed = value; } }
    public float MaxBounceAngle { set { MaxBounceAngle = value; }}
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Basically, if you hit the player figure, calculate the angle for the bounce like this:
    /// if the ball hits the exact center of the figure, the ball will simply bounce upwards
    /// the further the ball is from the center, the bigger the angle will be, the max angle being defined on the inspector
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

            //x and y component from the direction vector
            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Abs(Mathf.Sin(angleInRadians));

            Vector2 direction = new Vector2(x, y).normalized;

            rb.velocity = direction * ballSpeed;
        }
        else // if the object hit is not the player figure, then simply reflect the bounce in the opposite direction
        {
            Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflection.normalized * ballSpeed;
        }
    }
}
