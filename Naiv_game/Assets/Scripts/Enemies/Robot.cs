using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{


    private Rigidbody2D _mybody;
    private Animator _anim;

    public GameObject _firePoint;

    private Vector3 _moveDirection = Vector3.left;
    private Vector3 _originPosition;
    private Vector3 _movePosition;

    public GameObject _bullet;
    public LayerMask _playerLayer;

    private bool _canMove;
    private bool _attack = true;


    private float _playerXPoaition;
    private float _playerYPoaition;

    private float _EnemyXPoaition;
    private float _EnemyYPoaition;

    private Collider2D _shootingRang;


    void Awake()
    {
        _mybody = GetComponent<Rigidbody2D>();
        //  _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _originPosition = transform.position;
        _originPosition.x += 6f;

        _movePosition = transform.position;
        _movePosition.x -= 6f;

        _canMove = true;


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        if (_canMove)
        {
            transform.Translate(_moveDirection * 2f * Time.smoothDeltaTime);

            if (transform.position.x >= _originPosition.x)
            {
                _moveDirection = Vector3.left;
                changeDirection();
            }
            else if (transform.position.x <= _movePosition.x)
            {
                _moveDirection = Vector3.right;
                changeDirection();
            }
        }
    }

    void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = transform.localScale.x * -1f;
        transform.localScale = tempScale;

        // tempScale = _firePoint.localScale;
        // tempScale.x = _firePoint.localScale.x * -1f;
        //_firePoint.localScale = tempScale;


       _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f);


    }


    void Fire()
    {
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);

         _shootingRang = Physics2D.OverlapCircle(temp, 5f, _playerLayer);

         _playerXPoaition = _shootingRang.transform.position.x;
         _playerYPoaition = _shootingRang.transform.position.y;

         _EnemyXPoaition = transform.position.x;
         _EnemyYPoaition = transform.position.y;

        if (_shootingRang )
        {
            _canMove = false;
            //Debug.Log("Attack!!");
            if (_attack)
            {
                if (_playerXPoaition < _EnemyXPoaition && _playerYPoaition < _EnemyYPoaition)
                {
                  //  Debug.Log("Left and Down !!");
                    Instantiate(_bullet, _firePoint.gameObject.transform.position  , _firePoint.gameObject.transform.rotation);
                   // _bullet.gameObject.GetComponent<RedLaser>().ChangeDirction(-1f, -1f);

                }
                else if (_playerXPoaition > _EnemyXPoaition && _playerYPoaition < _EnemyYPoaition)
                {
                    //Debug.Log("Right and Down !!");
                    Instantiate(_bullet, _firePoint.gameObject.transform.position, _firePoint.gameObject.transform.rotation);

                    //_bullet.gameObject.GetComponent<RedLaser>().ChangeDirction(1f, -1f);

                }
                else if (_playerXPoaition > _EnemyXPoaition && _playerYPoaition > _EnemyYPoaition)
                {
                    //Debug.Log("Right and Up!!");
                    Instantiate(_bullet, _firePoint.gameObject.transform.position ,_firePoint.gameObject.transform.rotation);

                    //_bullet.gameObject.GetComponent<RedLaser>().ChangeDirction(1f, 1f);

                }
                else if (_playerXPoaition < _EnemyXPoaition && _playerYPoaition > _EnemyYPoaition)
                {
                    //Debug.Log("Left and Up!!");
                    Instantiate(_bullet, _firePoint.gameObject.transform.position ,_firePoint.gameObject.transform.rotation);

                    //_bullet.gameObject.GetComponent<RedLaser>().ChangeDirction(-1f, 1f);

                }
                _attack = false;

                //_anim.Play("BirdFly");                                //TODO:change the animation

                StartCoroutine(WaitToFire(1f));
                //_shootingRang = null;
            }
        }
        else
        {
            _canMove = true;

        }
    

}


    IEnumerator RobotDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            _mybody.bodyType = RigidbodyType2D.Dynamic;

            _canMove = false;

            StartCoroutine(RobotDead());

        }
    }


    IEnumerator WaitToFire(float time)
    {
        yield return new WaitForSeconds(time);
       // Debug.Log("waited!!");

        _attack = true;

    }


}
