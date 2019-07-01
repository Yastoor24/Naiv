using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossHelth : MonoBehaviour
{
    private Animator anim;
    private int health = 1;
    private bool canDamage;
    void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            
            if (target.tag == "Bullet")
            {
                health--;
                canDamage = false;
                if (health == 0)
                {
                   
                    //
                    GetComponent<BossScript>().DeactiveateBossScript();
                    anim.Play("BossDead1");
                    target.gameObject.SetActive(false);
                   
                }
                StartCoroutine(WaitForDamage());
            }
        }
    }
} // class
