using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using System;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    SO_CannonGlobalSettings settings;

    [SerializeField]
    Transform startPoint;

    [SerializeField]
    Transform endPoint;

    Vector2 direction;

    public static Action<Queue<GameObject>, Vector2, float> OnLaunchProjectile;

    //temp
    [ShowInInspector]
    Queue<GameObject> projectileQueue;



    private void Start()
    {
        projectileQueue = new Queue<GameObject>(settings.MaxQueueCapacity);


        direction = (startPoint.position - endPoint.position).normalized;

        for(int i = 0; i < settings.MaxQueueCapacity; i++)
        {
            var tempProjectile = Instantiate(settings.EnemyProjectilePrefab, transform);
            projectileQueue.Enqueue(tempProjectile);
            var tempEP = tempProjectile.GetComponent<EnemyProjectile>();
            tempEP.OnProjectileTouchesBottom += ReQueue;
            tempEP.OnProjectileIsDisabled += ReQueue;
        }
    }



    public void Shoot()
    {
        if(projectileQueue.Count > 0)
            OnLaunchProjectile?.Invoke(projectileQueue, direction, settings.ProjectileInitialSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if(startPoint != null && endPoint != null)
            Gizmos.DrawLine(startPoint.position, endPoint.position);
    }



    private void ReQueue(GameObject projectile)
    {
        projectile.transform.localPosition = Vector3.zero;
        projectileQueue.Enqueue(projectile);

    }
}
