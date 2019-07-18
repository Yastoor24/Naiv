using System.Collections;


using System.Collections.Generic;
using UnityEngine;

public class RedLaser : MonoBehaviour
{

    private Animator _anim;


    [SerializeField]
    private float _speed = 0.5f;

   

    public Transform target;

    private Vector3 dir;

    float distanceThisFrame;

    private float  _slope;              // between player and bullet position to get the degree between them 
    private float _degree;

    void Awake()
    {
        //_anim = GetComponent<Animator>();

    }


    // Start is called before the first frame update
    void Start()
    {
        dir = target.position - transform.position;
        distanceThisFrame = 0.05f;

        _slope = (target.position.y - transform.position.y) / (target.position.x - transform.position.x);
        _degree = Mathf.Atan(_slope);

        //transform.RotateAroundLocal(dir, _degree);

   
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
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "PowerIcon")
        {
            Debug.Log(collision.gameObject.name);
            gameObject.SetActive(false);        //to destroy the bullet

        }
    }

}
