using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    #region Getters&Setters
    public AudioSource AudioSource { get { return audioSource; } set { audioSource = value; } }

    public static Action<AudioSource> OnBallIsDestroyedAUDIO;
    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ball"))
            OnBallIsDestroyedAUDIO.Invoke(audioSource);
    }
}
