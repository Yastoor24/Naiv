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

    private float speed = 2.5f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        movePosition = transform.position;
        movePosition.x -= 6f;

        canMove = true;
    }

    void Update()
    {
        MoveTheDrone();
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
}



//class





































