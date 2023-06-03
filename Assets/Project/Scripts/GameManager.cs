using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float ballSpeed;

    [SerializeField]
    private BallBounce ballBounceScriptReference;

    private void Awake()
    {
        InitializeBallBounceValues();
    }


    private void InitializeBallBounceValues()
    {
        ballBounceScriptReference.BallSpeed = ballSpeed;
    }
}
