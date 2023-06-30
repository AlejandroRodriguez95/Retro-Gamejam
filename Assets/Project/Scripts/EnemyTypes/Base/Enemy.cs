using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected E_EnemyType type;
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected int currentHealth;
    protected float attackCooldown;
    [SerializeField]
    private static GameObject[] powerUps;
    public static Action specialEffectsWhenHit;


    public abstract void Shoot();
    public abstract void Patrol();
    public virtual void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage(GameObject Ball) { }
    public virtual void ApplySpecialEffects()
    {
        specialEffectsWhenHit?.Invoke();
    }
    public abstract IEnumerator AttackingPattern();
}
