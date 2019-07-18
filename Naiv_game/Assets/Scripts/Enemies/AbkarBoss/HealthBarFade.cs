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
    public static bool heelState = false;
    public  int healthValue=100;
    public static int amount;

   
    private void Awake()
    { 
         
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damageBar").GetComponent<Image>();
    }

    private void Start()
    {
        healthSystem = new HealthSystem(95);
        SetHealth(healthSystem.GetHealthNormalized());
        damagedBarImage.fillAmount = barImage.fillAmount;

    }

    private void Update()
    {


        if (barImage.fillAmount > 0.71 && barImage.fillAmount <= 1)
        {
            barImage.color = new Color(0.4745098f, 0.6f, 0.3137255f, 1f);
        }
        else if (barImage.fillAmount > 0.519 && barImage.fillAmount <= 0.71)
        {
            barImage.color = new Color(0.9245283f, 0.9240205f, 0.3794055f, 1f);
        }
        
        else if (barImage.fillAmount > 0.233 && barImage.fillAmount<= 0.519)
        {
            barImage.color = new Color(0.9245283f, 0.6192496f, 0.1788003f, 1f);
        }
        else if (barImage.fillAmount> 0.16 && barImage.fillAmount <= 0.233)
        {
            barImage.color = new Color(0.7924528f, 0.09344961f, 0.1232623f, 1f);
        }



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

        if (heelState)
        {
            if (healthSystem.healthAmount < 100)
            {
                healthSystem.Heal(amount);
                HealthSystem_OnHealed();
                heelState = false;
                healthValue = healthSystem.healthAmount;
            }


        }


    }

    private void HealthSystem_OnDamaged()
    {
        damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER_MAX;
        SetHealth(healthSystem.GetHealthNormalized());

       

    }

    private void HealthSystem_OnHealed()
    {
        SetHealth(healthSystem.GetHealthNormalized());
        damagedBarImage.fillAmount = barImage.fillAmount;
    }

    private void SetHealth(float healthNormalized)
    {
        barImage.fillAmount = healthNormalized;
    }

    
}
