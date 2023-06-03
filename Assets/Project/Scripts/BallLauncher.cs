using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject ball;


    void Start()
    {
        ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15 + new Vector2(1, 2), ForceMode2D.Impulse);
    }

}
