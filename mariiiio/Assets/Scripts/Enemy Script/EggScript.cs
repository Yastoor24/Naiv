using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    // Start is called before the first frame update
   void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == MyTags.PLAYER_TAG)
        {
            //player damage 
            target.gameObject.GetComponent<DamageScript>().DealDamage();
        }
        gameObject.SetActive(false);
    }
}
