using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected static List<GameObject> currentBalls = new List<GameObject>();

    Rigidbody2D rb;
    protected void Awake()
    {
        LauncherBehavior.OnBallLaunch += AddCurrentBall;
        BallDestroyer.OnBallIsDestroyed += RemoveCurrentBall;
        rb = GetComponent<Rigidbody2D>();
    }

    protected void OnEnable()
    {
        rb.velocity = Vector3.down * 2;
    }

    public void Activate(Collision2D collision) {
        collision.gameObject.SetActive(false);
        Debug.Log("power up collected");
    }



    void AddCurrentBall(GameObject newBall)
    {
        currentBalls.Add(newBall);
    }

    void RemoveCurrentBall(GameObject currentBall){
        currentBalls.Remove(currentBall);
    }
}
