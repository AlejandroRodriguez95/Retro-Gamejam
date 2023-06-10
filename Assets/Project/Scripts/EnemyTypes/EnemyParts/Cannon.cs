using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Cannon : MonoBehaviour
{
    [SerializeField]
    Transform startPoint;

    [SerializeField]
    Transform endPoint;

    Vector2 direction;

    //temp
    [SerializeField]
    GameObject projectile;

    private void Start()
    {
        direction = (endPoint.position - startPoint.position).normalized;
    }



    public void Shoot()
    {
        // this is temporary and will be modified so that it uses a queue and object pooling like the ball launcher
        var go = Instantiate(projectile, endPoint.position, Quaternion.identity, this.transform);
        go.GetComponent<Rigidbody2D>().velocity = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if(startPoint != null && endPoint != null)
            Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
