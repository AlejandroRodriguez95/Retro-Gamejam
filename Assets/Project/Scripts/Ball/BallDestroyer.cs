using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    AudioSource audioSource;

    #region Getters&Setters
    public AudioSource AudioSource { get { return audioSource; }}

    public static Action<AudioSource> OnBallIsDestroyedAUDIO;
    #endregion

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
            OnBallIsDestroyedAUDIO.Invoke(audioSource);
    }
}
