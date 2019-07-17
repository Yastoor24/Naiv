using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Enemy
{

    private bool moveLeft;
    private bool attacks;
    private bool stunned;
    [SerializeField]
    public Transform  top_Collision, down_Collision;
    private GameObject _player;
  
    private Vector3 left_Collision_Pos, right_Collision_Pos;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
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
        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, playerLayer);

        if (topHit != null)
        {
            if (topHit.gameObject.tag =="Enemy")
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);

                    anim.Play("Dead");
                    stunned = true;
                    print("lizard dead");

                    // BEETLE CODE HERE
                
                }
            }
        }

       
        // IF we don't detect collision any more do whats in {}
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))
        {

            ChangeDirection();
        }

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




    public void OnCollisionEnter2D(Collision2D target)
    {
    
        if ( ! (target.gameObject.tag == "Ground") )
        {
            myBody.velocity = new Vector2(0, 0);
            anim.Play("Dead");

            StartCoroutine(ttimer(1f));
            print("lizard dead");


        }
    
    }

    public IEnumerator ttimer(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }

































    //class

}
