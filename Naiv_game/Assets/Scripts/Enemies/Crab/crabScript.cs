using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crabScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public LayerMask playerLayer;
    private bool moveLeft;
    private bool canMove;
    private bool stunned;
    public Transform left_Collision, right_Collision, top_Collision, down_Collision;
    private Vector3 left_Collision_Pos, right_Collision_Pos;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        left_Collision_Pos = left_Collision.position;
        right_Collision_Pos = right_Collision.position;

    }

    void Start()
    {
        moveLeft = true;
        canMove = true;

    }


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
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.1f, playerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, playerLayer);

        if (topHit != null)
        {
            if (topHit.gameObject.tag == "Player")
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);

                    anim.Play("Stunned");
                    stunned = true;
                    StartCoroutine(Dead(0.5f));
                }
            }
        }
             

        if (leftHit)
        {
            if (leftHit.collider.gameObject.tag =="Player")
            {
                if (!stunned)
                {
                    // APPLY DAMAGE TO PLAYER
                    print("L player damge");
                }
              
            }
        }
        if (rightHit)
        {
            if (rightHit.collider.gameObject.tag == "Player")
            {
                if (!stunned)
                {
                    // APPLY DAMAGE TO PLAYER
                    print("R player damge");
                }
            
            }
        }

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


  

    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }




}
