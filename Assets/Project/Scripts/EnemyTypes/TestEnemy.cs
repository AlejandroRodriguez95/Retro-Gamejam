using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    [SerializeField]
    float spawnChance;

    [SerializeField]
    SO_EnemySettings initialValues;
    [SerializeField]
    Cannon[] cannons;

    [SerializeField]
    GameObject[] powerUps;

    private void Awake()
    {
        maxHealth = initialValues.maxHealth;
        attackCooldown = initialValues.attackCooldown;
        currentHealth = maxHealth;
        StartCoroutine(AttackingPattern());
    }

    public override void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SpawnPowerUp();
        }
    }
    public override void TakeDamage(GameObject ball)
    {
        int damageDealt = ball.GetComponent<Ball>().DamageDealt;
        currentHealth -= damageDealt;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SpawnPowerUp();
        }
    }

    protected void SpawnPowerUp()
    {
        if (UnityEngine.Random.Range(0, 100) < spawnChance)
        {
            int powerUpIndex = 0;
            Instantiate<GameObject>(powerUps[powerUpIndex], gameObject.transform.position, gameObject.transform.rotation).SetActive(true);
        }
    }

    public override void Shoot()
    {
        if(cannons.Length > 0)
        {
            foreach(Cannon cannon in cannons)
            {
                cannon.Shoot();
            }
        }
    }

    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("reflected projectile"))
        {
            TakeDamage();
        } else if (collision.gameObject.CompareTag("ball"))
        {
            TakeDamage(collision.gameObject);
        }
    }

    public override IEnumerator AttackingPattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackCooldown);
            Shoot();
        }
    }
}
