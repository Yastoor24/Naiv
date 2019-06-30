using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaser : MonoBehaviour
{

    private Animator _anim;

    private float _speed = 0.5f;

   

    public Transform target;

    private Vector3 dir;

    float distanceThisFrame;

    void Awake()
    {
        //_anim = GetComponent<Animator>();

    }


    // Start is called before the first frame update
    void Start()
    {
        dir = target.position - transform.position;
        distanceThisFrame = 0.05f;

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Move();


    }

    void Move()
    {

        transform.Translate(dir * distanceThisFrame, Space.World);

    }



     void OnTriggerEnter2D(Collider2D collision)
    {

        //_anim.Play("Destroy");              //change the name of the animation
        if (collision.gameObject.tag != "Enemy")
        {
            gameObject.SetActive(false);        //to destroy the bullet

        }
    }

}
