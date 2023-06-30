using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    SO_PlayerSettings playerSettings;

    public static Action<Collision2D> OnSpawnBallPickup;
    public static Action<Collision2D> OnFasterBallPickup;
    public static Action<Collision2D> OnBiggerBallPickup;
    public static Action<Collision2D> OnExtraDamagePickup;

    float speed;
    float bounds;

    public float Bounds { get { return bounds; } set { bounds = value; } }

    private bool isMovingLeft;
    private bool isMovingRight;

    private void Awake()
    {
        speed = playerSettings.MoveSpeed;
        bounds = playerSettings.Bounds;
        
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isMovingLeft)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);
        }

        if (isMovingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);
        }
    }


    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
            isMovingLeft = true;

        if (context.canceled)
            isMovingLeft = false;
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
            isMovingRight = true;

        if (context.canceled)
            isMovingRight = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spawn ball"))
            OnSpawnBallPickup?.Invoke(collision);

        if (collision.gameObject.CompareTag("faster ball"))
            OnFasterBallPickup?.Invoke(collision);

        if (collision.gameObject.CompareTag("bigger ball"))
            OnBiggerBallPickup?.Invoke(collision);

        if (collision.gameObject.CompareTag("extra damage"))
            OnExtraDamagePickup?.Invoke(collision);
    }

}