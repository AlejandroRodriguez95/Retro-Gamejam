using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody2D rb;

    float ballInitialSpeed = 11f;
    float maxBounceAngle = 90;
    float minBounceAngle = 25;

    //these values are modified either through the inspector or assigned by the game manager

    public static Action<GameObject> OnBallTouchesBottom;
    public static Action OnBallCollidesWithObject; // use this for sounds and physic handling

    #region Getters&Setters
    public float BallInitialSpeed { get { return ballInitialSpeed; } set { ballInitialSpeed = value; } }
    public float MaxBounceAngle { set { maxBounceAngle = value; }}
    public float MinBounceAngle { set { minBounceAngle = value; }}
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
        HandleCollision(collision);

        OnBallCollidesWithObject?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ball catcher"))
        {
            ResetBall();
            OnBallTouchesBottom?.Invoke(gameObject);
        }
    }

    public void LaunchBall(Vector2 direction)
    {
        rb.velocity = direction * ballInitialSpeed;
    }
    public void LaunchBall()
    {
        rb.velocity = Vector2.up * ballInitialSpeed;
    }

    private void ResetBall()
    {
        this.gameObject.SetActive(false);
    }

    private void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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

            rb.velocity = direction * ballInitialSpeed;
        }
        else if (collision.gameObject.CompareTag("walls"))// if the object hit is not the player figure, then simply reflect the bounce in the opposite direction
        {
            Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflection.normalized * ballInitialSpeed;
        }
    }
}
