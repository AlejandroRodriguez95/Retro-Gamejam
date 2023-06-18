using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    float ballInitialSpeed = 11;
    float maxBounceAngle = 90;
    float minBounceAngle = 15;

    //these values are modified either through the inspector or assigned by the game manager

    public Action<GameObject> OnProjectileTouchesBottom;
    public static Action<Collision2D, float, float, float> OnProjectileBouncesOnPlayer;
    public static Action<Collision2D, float> OnProjectileBouncesNormally;
    public static Action<AudioSource> OnProjectileCollidesWithObjectAUDIO; // use this for sounds 
    public Action<GameObject> OnProjectileIsDisabled;


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
        if (gameObject.CompareTag("reflected projectile"))
        {
            StopCoroutine(WaitAndDissapear(2));
            StartCoroutine(WaitAndDissapear(0));
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitAndDissapear(2));
            OnProjectileBouncesOnPlayer?.Invoke(collision, ballInitialSpeed, minBounceAngle, maxBounceAngle);
            OnProjectileCollidesWithObjectAUDIO?.Invoke(audioSource);
        }

        if (collision.gameObject.CompareTag("Normal bounce"))
        {
            OnProjectileBouncesNormally?.Invoke(collision, ballInitialSpeed);
            OnProjectileCollidesWithObjectAUDIO?.Invoke(audioSource);
        }        
        if (collision.gameObject.CompareTag("ally boss"))
        {
            StartCoroutine(WaitAndDissapear(0));
            OnProjectileCollidesWithObjectAUDIO?.Invoke(audioSource);
        }

        if (collision.gameObject.CompareTag("Ball goes through"))
            Debug.Log("Ball went through");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball catcher"))
        {
            ResetBall();
            OnProjectileTouchesBottom?.Invoke(gameObject);
        }
    }

    private void ResetBall()
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator WaitAndDissapear(float seconds)
    {
        this.gameObject.tag = "reflected projectile";

        yield return new WaitForSeconds(seconds);

        if (gameObject.activeSelf)
        {
            OnProjectileIsDisabled?.Invoke(gameObject);
            gameObject.SetActive(false);
        }
    }
}
