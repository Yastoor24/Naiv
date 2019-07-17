using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Enemy
{

    private bool moveLeft;
    private bool attacks;

    
    [SerializeField]
    private Transform down_Collision;
    private GameObject _player;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // _player = GameObject.FindGameObjectWithTag("Player");
        _enemyHealth = 3;
        speed = 1f;
        canMove = true;
        deadAnim = "Dead";

    }

    void Start()
    {
        moveLeft = true;
        attacks = false;
    }

    void Update()
    {
        Move();
    }

        private void Move()
    {
        if (canMove)
        {

            //attack();

            if (moveLeft)
            {
                myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            
            }
            else
            {
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
                

            }
        }

        CheckCollision();

    }

    void attack()
    {
        float _distance = transform.position.x - _player.transform.position.x;
        if (_distance == 1f || _distance == -1f)
        {
            print("test 1");
            anim.Play("Attack");
        }
        else
        {
            print("test 2");
            anim.Play("move");

        }
       

    }

    void CheckCollision()
    {





        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))


            ChangeDirection();


    }

    void ChangeDirection()
    {

        moveLeft = !moveLeft;

        Vector3 tempScale = transform.localScale;

        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);

        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);

        }

        transform.localScale = tempScale;

    }


    public IEnumerator timer(float time)
    {

        yield return new WaitForSeconds(time);
     

    }







































    //class

}
