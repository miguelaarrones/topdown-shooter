using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;  
    }

    public float GetHealth() => currentHealth;
}
