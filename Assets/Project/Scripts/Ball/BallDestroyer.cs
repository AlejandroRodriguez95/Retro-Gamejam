using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public static Action<GameObject> OnBallIsDestroyed;
    public static Action<AudioSource> OnBallIsDestroyedAUDIO;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            OnBallIsDestroyed.Invoke(collision.gameObject);
            OnBallIsDestroyedAUDIO.Invoke(audioSource);
        }

        if(collision.CompareTag("power up"))
            Destroy(collision.gameObject);
    }
}
