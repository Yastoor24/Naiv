using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;
    

    private bool canMove;

    private float speed = 8f;


    // Start is called before the first frame update
     void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
  
  
        void Start()
    {
        
            originPosition = transform.position;
            originPosition.x += 8f;

            movePosition = transform.position;
            movePosition.x -= 8f;
        
        canMove = true;
    }

    // Update is called once per frame
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


            }

            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;

            }
            
        

        }
    }

}
