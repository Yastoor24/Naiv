using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Rigidbody2D _mybody;
    private Animator _anim;

    public GameObject _firePoint;

    private Vector3 _moveDirection = Vector3.right;
    private Vector3 _originPosition;
    private Vector3 _movePosition;

    public GameObject _bullet;
    public LayerMask _playerLayer;

    private bool _canMove;
    private bool _attack = true;


    GameObject _player;

    void Awake()
    {
        _mybody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
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


       _firePoint.gameObject.transform.transform.Rotate(0f, 180F, 0f); // to flip the position of firing
    }


    void Fire()
    {
       
        float _distance = Vector3.Distance(transform.position, _player.transform.position);

        if (_distance > 8f)
        {
            _canMove = true;           
        }

        if ( _distance < 5)
        {
            _canMove = false;

            if (_attack)
            {
                    Instantiate(_bullet, _firePoint.gameObject.transform.position  , _firePoint.gameObject.transform.rotation);
                    _bullet.gameObject.GetComponent<RedLaser>().target = _player.transform;   //pass the player position to bullet script

                _attack = false;

                //_anim.Play("BirdFly");                                //TODO:change the animation

                StartCoroutine(WaitToFire(1f));
            }
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

        _attack = true;
        
    }


}
