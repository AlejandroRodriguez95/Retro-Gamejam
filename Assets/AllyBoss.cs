using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AllyBoss : MonoBehaviour
{

    public static Action<int> OnAllyBossTakesHit;

    int damageFromBall;
    int damageFromProjectile;

    [SerializeField]
    SO_AllyBossSettings settings;

    private void Awake()
    {
        damageFromBall = settings.DamageFromBall;
        damageFromProjectile = settings.DamageFromProjectile;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            OnAllyBossTakesHit?.Invoke(damageFromBall);
        }

        if(collision.gameObject.CompareTag("enemy projectile") || collision.gameObject.CompareTag("reflected projectile"))
        {
            OnAllyBossTakesHit?.Invoke(damageFromProjectile);
        }
    }
}
