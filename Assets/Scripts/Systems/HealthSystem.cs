using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    public Action<float> OnLifeChange;
    public Action onDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(float toIncrease)
    {
        currentHealth += toIncrease;
        OnLifeChange?.Invoke(currentHealth);
        
    }    
    public void DecreaseHealth(float toDecrease)
    {
        currentHealth -= toDecrease;
        OnLifeChange?.Invoke(currentHealth);
        
        if (currentHealth <= 0)
        {
            onDead?.Invoke();
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
