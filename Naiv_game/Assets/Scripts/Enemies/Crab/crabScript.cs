using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crabScript : Enemy
{


    private bool moveLeft;
    private bool stunned;
    public Transform down_Collision;



    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _enemyHealth = 3;
        speed = 1f;
        canMove = true;

    }

    void Start()
    {
        moveLeft = true;

    }


    void Update()
    {
        if (canMove)
        {
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






}
