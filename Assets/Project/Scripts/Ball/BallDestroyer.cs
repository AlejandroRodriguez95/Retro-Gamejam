using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public static Action<AudioSource> OnBallIsDestroyedAUDIO;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
            OnBallIsDestroyedAUDIO.Invoke(audioSource);
    }
}
