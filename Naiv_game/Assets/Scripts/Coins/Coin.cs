using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject medKitBox;
    private Text _MedKitTextScore;
    public static int _MedKitCount=0;
    private bool state = true;
    private bool yesState = false;





    void Start()
    {

        _MedKitTextScore = GameObject.Find("MedKitText").GetComponent<Text>();

        load();


    }

    private void Update()
    {
        _MedKitTextScore.text = "MedKit " + _MedKitCount;
        if (_MedKitCount == 3)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (state)
                {
                    medKitBox.SetActive(true);
                    state = false;
                }
                else
                {
                    medKitBox.SetActive(false);
                    state = true;
                }
            }

        }

    }
    public void Back()
    {

        load();
        Debug.Log("loading level and previous position");
        StartCoroutine(RestartGame());
    }

    void load()
    {
        if (PlayerPrefs.GetFloat("x") != null)
        {
            // transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            save();
        }
    }

    void save()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
    }






    // calculate the plyer life score && aid box score

    void OnTriggerEnter2D(Collider2D target)
    {
        // if the coin be AidBox
        if (target.tag == "MedKit")
        {
            target.gameObject.SetActive(false);
            if (_MedKitCount < 3)
            {
                _MedKitCount++;
                _MedKitTextScore.text = "MedKit " + _MedKitCount;
            }

        }



        if (target.gameObject.tag == "EnemyBullet"  || target.gameObject.tag == "SuperEnemyBullet")
        { playerDead(); }


    }

    // detect the collision the player with enemy &  PlayerBullet and decrease the player life or dead him
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {

            playerDead();

        }

       else if (target.gameObject.tag == "fallout")
        {

            playerDead();

            if (_lifeCount > 0)
            {

                transform.position = BoxReturn.position;
            }

        }

    }



    void playerDead()
    {



        if (HealthBarFade.healthValue > 0)
        {
            // decrease the life by one
            HealthBarFade.damState = true;

            // player dead and back to last place



        }
        else if (HealthBarFade.healthValue == 0)
        {


            // player dead; if lifes for player <0 then return from began (game over).


            StartCoroutine(RestartGame());


            // reset the score to default

            print("Game over");
            HealthBarFade.amount = 100;
            HealthBarFade.heelState = true;
            _MedKitCount = 0;
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("Old Village House");
    }
}
