using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D rb;
    protected void Awake()
    {
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
}
