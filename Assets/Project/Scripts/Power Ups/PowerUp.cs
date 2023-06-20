using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected static GameObject currentBall;

    Rigidbody2D rb;
    protected void Awake()
    {
        LauncherBehavior.OnBallLaunch += SetCurrentBall;
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



    void SetCurrentBall(GameObject newBall)
    {
        currentBall = newBall;
    }
}
