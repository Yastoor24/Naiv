using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{


    public int healthAmount;
    public int healthAmountMax;

    public HealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;

        if (healthAmount < 0)
        {
            healthAmount = 0;
        }
   
    }

    public void Heal(int amount)
    {
        healthAmount += amount;
        if (healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
   
    }


    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
