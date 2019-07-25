using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatFormMovement1 : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    public GameObject Player;

    [SerializeField]

    private Vector3 speedVar;

    private bool platformMoving;



    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platformMoving = true;
            collision.collider.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
    
        platformMoving = false;
        collision.collider.transform.SetParent(null);
    
    }


    private void FixedUpdate()
    
    {
        if (platformMoving)
        {
            transform.position += (speedVar * Time.deltaTime);
        }
    }

            // Use this for initialization
    
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }

    //public void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.tag == "Player")
        //{
            //other.transform.parent = transform;
        //}
    //}

    //public void OnTriggerExit2D(Collider2D other)
    //{
        //if (other.gameObject.CompareTag("Ground") && playerctrl.isJumping)
        //{
            //playerctrl.isJumping = false;
        //}

    //}

}