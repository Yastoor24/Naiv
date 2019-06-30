using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameobjectdamage : MonoBehaviour
{


    public Transform LeftCollision, RightCollision,
                      TopCollision, down_Collision;
    private Vector3 LeftCollision_Pos, RightCollision_Pos;


    //void Awake()
    //{
    //    myBody = GetComponent<Rigidbody2D>();
    //    anim = GetComponent<Animator>();
    //    LeftCollision_Pos = LeftCollision.position;
    //    RightCollision_Pos = RightCollision.position;

    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    moveLeft = true;
    //    canMove = true;

    //}


    //void update()
    //{
    //    CheckCollision();
    //}
    //// Start is called before the first frame update
    //void CheckCollision()
    //{

    //    RaycastHit2D leftHit = Physics2D.Raycast(LeftCollision.position, Vector2.left, 0.1f, PlayerLayer);
    //    RaycastHit2D rightHit = Physics2D.Raycast(RightCollision.position, Vector2.right, 0.1f, PlayerLayer);

       

       
     

    //    if (leftHit)
    //    {
    //        if (leftHit.collider.gameObject.tag == "Player")
    //        {
    //            if (!stunned)
    //            {
    //                //applay damage to player

    //                leftHit.collider.gameObject.GetComponent<DamageScript>().DealDamage();
    //            }
    //            else
    //            {
    //                if (tag != "damage")
    //                {
                     
                      
    //                }
    //            }
    //        }
    //    }
    //    if (rightHit)
    //    {
    //        if (rightHit.collider.gameObject.tag == "Player")
    //        {
    //            if (!stunned)
    //            {

    //                //applay damage to player
    //                rightHit.collider.gameObject.GetComponent<DamageScript>().DealDamage();
    //            }
    //            else
    //            {

    //                if (tag != "damage")
    //                {
    //                    myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                        
    //                }
    //            }
    //        }
    //    }
    //    //if we don't detect collision anymore  so do what in 37
       
        

    }


