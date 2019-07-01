using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft;

    private bool canMove;
    private bool stunned;

    public LayerMask PlayerLayer;

    public Transform LeftCollision, RightCollision,
                       TopCollision, down_Collision;
    private Vector3 LeftCollision_Pos, RightCollision_Pos;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LeftCollision_Pos = LeftCollision.position;
        RightCollision_Pos = RightCollision.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            if (moveLeft)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }
            else
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }
        }
        CheckCollision();

    }
    void CheckCollision()
    {

        RaycastHit2D leftHit = Physics2D.Raycast(LeftCollision.position, Vector2.left, 0.1f, PlayerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(RightCollision.position, Vector2.right, 0.1f, PlayerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(TopCollision.position, 0.2f, PlayerLayer);

        if (topHit != null)
        {
            if (topHit.gameObject.tag == "Player")
            {
                if (!stunned)
                { //the already wrote in s ...
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);
                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);
                    anim.Play("Stunned");
                    stunned = true;
                    //Beetel  code here

                    if (tag == "Beetle")
                    {
                        anim.Play("Stunned");
                        StartCoroutine(Dead(3f));

                    }
                }
            }
        }

        if (leftHit)
        {
            if (leftHit.collider.gameObject.tag == "Player")
            {
                if (!stunned)
                {
                    //applay damage to player

                    leftHit.collider.gameObject.GetComponent<DamageScript>().DealDamage();
                }
                else
                {
                    if (tag != "Beetle")
                    {
                        myBody.velocity = new Vector2(15f, myBody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        if (rightHit)
        {
            if (rightHit.collider.gameObject.tag == "Player")
            {
                if (!stunned)
                {

                    //applay damage to player
                    rightHit.collider.gameObject.GetComponent<DamageScript>().DealDamage();
                }
                else
                {

                    if (tag != "Beetle")
                    {
                        myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }
        //if we don't detect collision anymore  so do what in 37
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
            //here we are storing the postion here
            LeftCollision.position = LeftCollision_Pos;
            RightCollision.position = RightCollision_Pos;
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            LeftCollision.position = RightCollision_Pos;
            RightCollision_Pos = LeftCollision.position;

        }
        transform.localScale = tempScale;

    }
    //void OnCollisionEnter2D (Collision2D target) {
    //here when the tag==palyrer...then let the the snill stuned using anim var
    //  if( target.gameObject.tag == "Player") {

    //anim.Play("Stunned");

    //  }
    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);


    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            if (tag == "Beetle")
            {
                anim.Play("Stunned");
              
              
                canMove = false;
                myBody.velocity = new Vector2(0, 0);
                StartCoroutine(Dead(0.4f));
                target.gameObject.SetActive(false);

            }
            if (tag == "Snail")
            {
                if (!stunned)
                {
                    anim.Play("Stunned");
                  
                  
                    stunned = true;
                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);

                    target.gameObject.SetActive(false);



                }
                else
                {
                    gameObject.SetActive(false);
                    target.gameObject.SetActive(false);


                }
            }
        }
    }
}
