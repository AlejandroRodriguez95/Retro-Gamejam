using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    private bool isMovingLeft;
    private bool isMovingRight;



    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isMovingLeft)
            transform.position -= new Vector3(speed * Time.deltaTime, 0);

        if(isMovingRight)
            transform.position += new Vector3(speed * Time.deltaTime, 0);
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
}