using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;  
    }

    public float GetHealth() => currentHealth;

    public void IncreaseHealth(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
    }
}
