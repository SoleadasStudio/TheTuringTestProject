using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject gameOverText;

    public Action<float> OnHealthUpdate;

    private float health;

    void Start()
    {
        health = maxHealth;

       // OnHealthUpdate(maxHealth);
    }

    public void DeductHealth(float value)
    {
        health -= value;

        Debug.Log(health);
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        OnHealthUpdate(health);
    }

    private void Die()
    {
        gameOverText.SetActive(true);
    }
}
