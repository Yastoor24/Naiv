using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Text _lifeTextScore;
    private Text _aidBoxTextScore;
    private int _lifeCount;
    private int _aidBoxCount;  
   
  


    void Start()
    {
        _lifeTextScore = GameObject.Find("LifeText").GetComponent<Text>();
        _aidBoxTextScore = GameObject.Find("AidBoxText").GetComponent<Text>();
       

    }

    // calculate the plyer life score && aid box score  
    
    void OnTriggerEnter2D(Collider2D target)
    {
        // if the coin be AidBox
        if (target.tag == "AidBox")
        {
            target.gameObject.SetActive(false);

           
            if (_aidBoxCount < 50)
            {
               
                _aidBoxCount++;
                _aidBoxTextScore.text = "AidBox " + _aidBoxCount;
            }
            // if AidBox equals 50 we wants to check if life score reach to maxmim score or not if not add 1 to life score then return the aidbox store to 0
            else if (_aidBoxCount == 50)
            {
                if (_lifeCount < 6)
                {
                    _lifeCount++;
                    _lifeTextScore.text = "Life " + _lifeCount;
                }

                _aidBoxCount = 0;
                _aidBoxTextScore.text = "AidBox " + _aidBoxCount;
            }


        }
        // if the coin be heart (life )
        else if (target.tag == "Life")
        {
            target.gameObject.SetActive(false);
            //to check if we reach to maxmim value or not 
            if (_lifeCount < 6)
            {
                _lifeCount++;
                _lifeTextScore.text = "Life " + _lifeCount;

            }

        }



    }

  

    // detect the collision the player with enemy &  PlayerBullet and decrease the player life or dead him
    void OnCollisionEnter2D (Collision2D target)
    {
        if (target.gameObject.tag == "Enemy" || target.gameObject.tag == "EnemyBullet")
        {
            if (_lifeCount > 0)
            {
                // decrease the life by one
                _lifeCount--;
                _lifeTextScore.text = "Life " + _lifeCount;
                print("dead");
                // player dead and back to last place

                 /* كود شيماء */

            }
            else if (_lifeCount == 0)
            {
                // player dead;

                /* كود شيماء */



                // reset the score to default 

                print("Game over");
                _lifeCount = 2;
                _aidBoxCount = 0;
            }

        }

    }


  
  



}
