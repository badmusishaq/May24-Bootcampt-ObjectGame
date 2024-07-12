using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;

    public float GetHealth()
    {
        return currentHealth;
    }
    public Health(float _maxHealth, float _healthRegenRate, float _currentHealth = 100)
    {
        currentHealth = _currentHealth;
        maxHealth = _maxHealth;
        healthRegenRate = _healthRegenRate;
    }

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }

    public Health()
    {

    }

    public void RegenHealth()
    {
        AddHealth(healthRegenRate * Time.deltaTime);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(currentHealth, currentHealth + value);
    }

    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
    }
}
