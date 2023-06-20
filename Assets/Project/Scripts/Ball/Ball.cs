using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    float ballInitialSpeed;
    float maxBounceAngle;
    float minBounceAngle;

    //these values are modified either through the inspector or assigned by the game manager

    public static Action<GameObject> OnBallTouchesBottom;
    public static Action<Collision2D, float, float, float> OnBallBouncesOnPlayer;
    public static Action<Collision2D, float> OnBallBouncesNormally;
    public static Action<AudioSource> OnBallCollidesWithObjectAUDIO; // use this for sounds and physic handling

    #region Getters&Setters
    public float BallInitialSpeed { get { return ballInitialSpeed; } set { ballInitialSpeed = value; } }
    public float MaxBounceAngle { set { maxBounceAngle = value; } }
    public float MinBounceAngle { set { minBounceAngle = value; } }
    #endregion



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
            OnBallBouncesOnPlayer?.Invoke(collision, ballInitialSpeed, minBounceAngle, maxBounceAngle);
            OnBallCollidesWithObjectAUDIO?.Invoke(audioSource);
        }

        if (collision.gameObject.CompareTag("Normal bounce"))
        {
            OnBallBouncesNormally?.Invoke(collision, ballInitialSpeed);
            OnBallCollidesWithObjectAUDIO?.Invoke(audioSource);
        }
        if (collision.gameObject.CompareTag("ally boss"))
        {
            OnBallBouncesNormally?.Invoke(collision, ballInitialSpeed);
            OnBallCollidesWithObjectAUDIO?.Invoke(audioSource);
        }

        if (collision.gameObject.CompareTag("Ball goes through"))
            Debug.Log("Ball went through");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball catcher"))
        {
            ResetBall();
            OnBallTouchesBottom?.Invoke(gameObject);
        }
    }

    private void ResetBall()
    {
        this.gameObject.SetActive(false);
    }

    public void FasterBall(float powerLength, float speedScale)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(SpeedRescale(rb, powerLength, speedScale));;
        
    }

    private IEnumerator SpeedRescale(Rigidbody2D rb, float powerLength, float speedScale)
    {
        ballInitialSpeed *= speedScale;
        yield return new WaitForSeconds(powerLength);
        ballInitialSpeed /= speedScale;
    }
}
