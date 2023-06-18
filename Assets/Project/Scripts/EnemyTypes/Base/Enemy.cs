using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected E_EnemyType type;
    protected int maxHealth;
    protected int currentHealth;
    protected float attackCooldown;
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
    public virtual void ApplySpecialEffects()
    {
        specialEffectsWhenHit?.Invoke();
    }
    public abstract IEnumerator AttackingPattern();
}
