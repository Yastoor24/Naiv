using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : Enemy
{

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;

    public GameObject droneNet;
    private bool attacked = true;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 2f;
    }

    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 2f;

        movePosition = transform.position;
        movePosition.x -= 2f;

        canMove = true;
    }

    void Update()
    {
        MoveTheDrone();
        ThrowTheNet();
    }

    void MoveTheDrone()
    {
        if (canMove)
        {
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);

            if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;

                ChangeDirection(1/5f);
            }

            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;

                ChangeDirection(-1/5f);
            }
        }
    }

    void ChangeDirection(float direction)
    { 
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }


    private void ThrowTheNet()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
        {

            if (attacked == true)
            {
                anim.Play("DroneAttack");
                attacked = false;
                Instantiate(droneNet, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);


                StartCoroutine(WaitToThrow());
            }

        }
    }


    IEnumerator WaitToThrow()
    {
        yield return new WaitForSeconds(3f);
        attacked = true;

    }

    IEnumerator DroneDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerBullet")
        {
            anim.Play("DroneDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;

            StartCoroutine(DroneDead());


        }
    }

}



//class
