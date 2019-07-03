using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;

    public GameObject droneNet;
    public LayerMask PlayerLayer;
    private bool attacked;

    private bool canMove;

    private float speed = 2f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

                ChangeDirection(1f);
            }

            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;

                ChangeDirection(-1f);
            }
        }
    }

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void ThrowTheNet()
    {
        if (!attacked)
        {
            if (Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, PlayerLayer))
            {
                Instantiate(droneNet, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                attacked = true;
                //anim.Play("Dronefly");
            }
        }
    }


    IEnumerator DroneDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }


    //void OnTriggerEnter2D(Collider2D target)
    //{
      //  if (target.tag == "Bullet")
        //{
            //anim.Play("DroneDead");

         //   GetComponent<BoxCollider2D>().isTrigger = true;
          //  myBody.bodyType = RigidbodyType2D.Dynamic;

            //canMove = false;
            
            //StartCoroutine(DroneDead());


        //}
    //}

}



//class





































