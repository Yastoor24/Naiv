using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarFade : MonoBehaviour
{
    private const float DAMAGED_HEALTH_SHRINK_TIMER_MAX = .6f;

    private Image barImage;
    private Image damagedBarImage;
    private float damagedHealthShrinkTimer;
    public HealthSystem healthSystem;
    public static bool damState=false;
    public static bool EnemyDead = false;
    public static int healthValue=100;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damageBar").GetComponent<Image>();
    }

    private void Start()
    {
        healthSystem = new HealthSystem(100);
        SetHealth(healthSystem.GetHealthNormalized());
        damagedBarImage.fillAmount = barImage.fillAmount;
       



    }

    private void Update()
    {
        damagedHealthShrinkTimer -= Time.deltaTime;
        if (damagedHealthShrinkTimer < 0)
        {
            if (barImage.fillAmount < damagedBarImage.fillAmount)
            {
                float shrinkSpeed = 0.5f;
                damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }

        if (damState)
        { 
        if (healthSystem.healthAmount != 0)
        {
            healthSystem.Damage(5);
            HealthSystem_OnDamaged();
             damState = false;
                healthValue = healthSystem.healthAmount;
        }
        else if(healthSystem.healthAmount <= 0)
            {
                EnemyDead = true;

            }
    }


    }


   

    private void HealthSystem_OnDamaged()
    {
        damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER_MAX;
        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    }


}
