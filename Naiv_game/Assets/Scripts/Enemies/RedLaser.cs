using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaser : MonoBehaviour
{

    private Animator _anim;
    private float _xDirection, _yDirection;
    private float _xSpeed, _ySpeed = 0.5f;

    public Rigidbody2D _rb;


    public void ChangeDirction(float _x, float _y)
    {
        _xDirection = _x;
        _yDirection = _y;
        Debug.Log("CAlled");
    }


    void Awake()
    {
        //_anim = GetComponent<Animator>();
        _xSpeed *= _xDirection;
        _ySpeed *= _yDirection;

        _rb = gameObject.GetComponent<Rigidbody2D>();

    }


    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = transform.right * _xSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        Vector2 temp = transform.position;

        temp = new Vector2(transform.position.x  +0.1f, transform.position.y+ 0.1f);

        transform.position = temp;
        
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
