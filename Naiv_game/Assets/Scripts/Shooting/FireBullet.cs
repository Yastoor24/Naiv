using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float _speed = 60f;
    private Animator _anim;
    private bool _canMove;




    //Awake is used to initialize any variables or game state before the game starts
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _canMove = true;
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    // transfor the gameobject (Bullet)
    void Move()
    {
        if (_canMove)
        {
            Vector3 temp = transform.position;
            temp.x += _speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    // Encapsulation accsses for a private varible _speed 
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }


    }


    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        //Deactivate bullet if bullet doesn't hit anything 
        gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        //
        gameObject.SetActive(false);
    }
}
