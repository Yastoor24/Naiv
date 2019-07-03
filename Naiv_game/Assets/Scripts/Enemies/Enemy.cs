using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Rigidbody2D myBody;
    protected Animator anim;
    public LayerMask playerLayer;
    protected bool canMove;
    public float speed;

    protected int _enemyHealth;
    public GameObject _life;
    public GameObject _aidBox;
    protected bool _lifeState = false;
    protected bool _aidBoxtState = false;


    public Enemy()
    {

    }

    public void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "PlayerBullet")
        {
            print("bullet good");

            print("enemy health" + _enemyHealth);
            _enemyHealth--;
            if (_enemyHealth == 0)
            {
                canMove = false;
                myBody.velocity = new Vector2(0, 0);

                StartCoroutine(ResetMaterial(0.4f));

            }



        }
    }


    // called when enemy Dead 
    public void DropEnemies()
    {

        int _randNum = (int)Random.Range(1f, 10f);
        
        if (_randNum <= 2 || _randNum == 5 || _randNum == 6 || _randNum == 8 || _randNum == 9)
        {
            // nothing happiend
     

        }
        else if (_randNum == 4)
        {
            Vector3 life = transform.position;
            _life.transform.position = life;
            _life.SetActive(true);
            _lifeState = true;
            ObjectRepetition();
           

            // life
        }
        else if (_randNum == 3 || _randNum == 7 || _randNum == 10)
        {
            //   aid
            Vector3 aid = transform.position;
            _aidBox.transform.position = aid;
            _aidBoxtState = true;
            ObjectRepetition();
          

        }


    }


    // create more than one coins to DropEnemies method
    public void ObjectRepetition()
    {
        if (_lifeState)
        {
            GameObject t = Instantiate(_life);
            _lifeState = false;
        }
        else if (_aidBoxtState)
        {
            GameObject t = Instantiate(_aidBox);
            _aidBoxtState = false;
        }

    }

    public IEnumerator ResetMaterial(float time)
    {
      
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
        DropEnemies();
    }



}

