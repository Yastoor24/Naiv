using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private int lifeScoreCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerBullet")
        {
            if (tag == "Enemy")
            {


                lifeScoreCount--;

                if (lifeScoreCount >= 0)
                {


                    target.gameObject.SetActive(false);
                }

                if (lifeScoreCount == 0)
                {


                    gameObject.SetActive(false);




                }
            }

        }
    }
}

