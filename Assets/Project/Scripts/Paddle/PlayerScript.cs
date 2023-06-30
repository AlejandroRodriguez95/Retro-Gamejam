using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    int maxHealth;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    SO_PlayerSettings playerSettings;
    [SerializeField]
    SpriteRenderer healthBar;


    private void Awake()
    {
        maxHealth = playerSettings.MaxHealth;
        currentHealth = maxHealth;
        AllyBoss.OnAllyBossTakesHit += TakeDamage;
        UpdateHealthBar();
    }


    private void TakeDamage(int dmg)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("game over");
            SceneManager.LoadScene(2);
            return;
        }

        currentHealth -= dmg;
        UpdateHealthBar();
    }

    private void Heal(int dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth + dmg, 0, maxHealth);
    }

    private void UpdateHealthBar()
    {
        float t = (float)currentHealth/(float)maxHealth;

        
        healthBar.transform.localScale = new Vector3(t, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, t);
    }
}
